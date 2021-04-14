pipeline {
    agent any
    environment {
       REGISTRY = "registry.local:5000"
    }
    stages {
        stage('Verify') {
            steps {
                dir('playground') {
                    sh 'chmod +x ./ci/00-verify.bat'
                    sh './ci/00-verify.bat'
                }
            }
        }
        stage('Build') {
            steps {
                dir('playground') {
                    sh 'chmod +x ./ci/01-build.bat'
                    sh './ci/01-build.bat'
                }
            }
        }
        stage('Test') {
            steps {
                dir('playground') {
                    sh 'chmod +x ./ci/02-test.bat'
                    sh './ci/02-test.bat'
                }
            }
        }
        stage('Push') {
            steps {
                dir('playground') {
                    sh 'chmod +x ./ci/03-push.bat'
                    sh './ci/03-push.bat'
                    echo "Pushed web to http://$REGISTRY/v2/hedgehog/playground/tags/list"
                }
            }
        }
    }
}