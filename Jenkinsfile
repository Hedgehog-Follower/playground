pipeline {
    agent { label: 'kubepod' }
    environment {
       REGISTRY = "registry.local:5000"
    }
    stages {
        stage('Verify') {
            steps {
                dir('./') {
                    sh 'chmod +x ./ci/00-verify.bat'
                    sh './ci/00-verify.bat'
                }
            }
        }
        stage('Build') {
            steps {
                dir('./') {
                    sh 'chmod +x ./ci/01-build.bat'
                    sh './ci/01-build.bat'
                }
            }
        }
        stage('Test') {
            steps {
                dir('./') {
                    sh 'chmod +x ./ci/02-test.bat'
                    sh './ci/02-test.bat'
                }
            }
        }
        stage('Push') {
            steps {
                dir('./') {
                    sh 'chmod +x ./ci/03-push.bat'
                    sh './ci/03-push.bat'
                    echo "Pushed web to http://$REGISTRY/v2/hedgehog/playground/tags/list"
                }
            }
        }
        stage('Push') {
            steps {
              script {
                kubernetesDeploy(configs: "./.k8s/sending-api-deployment.yml", kubeconfigId: "mykubeconfig")
              }
            }
        }        
    }
}