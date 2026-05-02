@Library('checkmarx-one')_	
pipeline {
    agent { label 'win-runner-01' }

    environment {
        MSBUILD_PATH = 'C:\\Program Files\\Microsoft Visual Studio\\2022\\Professional\\MSBuild\\Current\\Bin\\MSBuild.exe'
        ZIP_NAME     = "ProductCRMAPI.zip"
        // Target IPs
        UAT_IP       = "10.129.5.155"
        STG_IP       = "10.129.5.175"
        PROD_IP      = "10.129.6.134"
    }

    stages {
        stage('Build') {
            steps {
                echo "Starting Build for ProductCRMAPI..."
                powershell """
                    git config --global --add safe.directory "${env.WORKSPACE}"
                    
                    # Run MSBuild
                    & "$MSBUILD_PATH" ProductCRMAPI.sln /p:Configuration=Release /p:DeployOnBuild=true /p:WebPublishMethod=Package /p:PackageAsSingleFile=true /p:SkipInvalidConfigurations=true
                    
                    # Locate the PackageTmp folder dynamically instead of hardcoded GitLab path
                    \$packagePath = Get-ChildItem -Path . -Recurse -Directory -Filter "PackageTmp" | Select-Object -ExpandProperty FullName -First 1
                    
                    if (\$packagePath) {
                        echo "Compressing from: \$packagePath"
                        Compress-Archive -Path "\$packagePath\\*" -DestinationPath "${env.ZIP_NAME}" -Force
                    } else {
                        Write-Error "Could not find PackageTmp directory!"
                        exit 1
                    }
                """
            }
            post {
                success {
                    // This replaces the GitLab 'artifacts' and 'package' stages
                    archiveArtifacts artifacts: "${env.ZIP_NAME}", fingerprint: true
                }
            }
        }

        // stage('Security Scan') {
        //     steps {
        //       script {
        //         securityScan()
        //       }
        //     }
        // }

        stage('Deploy_UAT') {
            when { branch 'UAT' }
            steps {
                input message: "Deploy to UAT (${env.UAT_IP})?"
                withCredentials([usernamePassword(credentialsId: 'healthbuzz-uat-creds', usernameVariable: 'U_USER', passwordVariable: 'U_PASS')]) {
                    powershell """
                        # Setup workspace
                        \$deployDir = "${env.WORKSPACE}\\deploy_ProductCRMAPI"
                        if (Test-Path \$deployDir) { Remove-Item -Recurse -Force \$deployDir }
                        New-Item -ItemType Directory -Force -Path \$deployDir
                        
                        # Authenticate and Extract
                        net use "\\\\${env.UAT_IP}\\C\$" /user:${env.U_USER} \$UAT_PASS /p:no
                        
                        # Expand directly into the deploy folder
                        Expand-Archive -Path "${env.ZIP_NAME}" -DestinationPath "\$deployDir" -Force
                        Remove-Item -Recurse "\$deployDir\\*.config" -ErrorAction SilentlyContinue

                        # Deploy
                        xcopy "\$deployDir\\*" "\\\\${env.UAT_IP}\\C\$\\Projects\\UAT\\ProductCRMAPI" /E /I /Y /C /J /L                       

                        # 3. Safe Cleanup Connection
                        # Check if the connection exists before attempting to delete
                        if (Get-PSDrive | Where-Object { \$_.DisplayRoot -eq "\\\\${env.UAT_IP}\\C\$" }) {
                            net use "\\\\${env.UAT_IP}\\C\$" /delete /y
                        } else {
                            echo "Network connection already closed or not found; skipping manual delete."
                        }                        
                                        """
                                    }
            }
        }

        stage('Deploy_Prod') {
            when { branch 'main' }
            steps {
                input message: "Proceed with PRODUCTION Deployment?"
                withCredentials([usernamePassword(credentialsId: 'healthbuzz-prod-creds', usernameVariable: 'P_USER', passwordVariable: 'P_PASS')]) {
                    powershell """
                        net use "\\\\${env.PROD_IP}\\F\$" /user:${env.P_USER} \$P_PASS /p:no
                        
                        # ... Similar Extraction logic as UAT ...
                        xcopy "\$deployDir\\*" "\\\\${env.PROD_IP}\\F\$\\Projects\\WSCignaAPI\\WSCignaAPI" /E /I /Y /C /J /L
                        
                        net use "\\\\${env.PROD_IP}\\F\$" /delete /y
                    """
                }
            }
        }
    }
}
