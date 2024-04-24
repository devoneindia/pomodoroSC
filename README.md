# pomodoroSC
Time Tracking App
        - name: Create Client Target Folder  
        run: ssh -o StrictHostKeyChecking=no -i /home/runner/work/pomodoroPK/pomodoroPK/Key/ls-rywds-dev-01-keypair-01.pem  ubuntu@3.213.39.34 'mkdir -p /var/www/html/devpkapps/pomodoro/$(date +"%Y%m%d%H%M")'
      - name: Copy Client files to EC2 instance
        run: scp -o StrictHostKeyChecking=no -r -i /home/runner/work/pomodoroPK/pomodoroPK/Key/ls-rywds-dev-01-keypair-01.pem /home/runner/work/pomodoroPK/pomodoroPK/pomodoro.client/dist/pomodoro.client/browser/* 'ubuntu@3.213.39.34:/var/www/html/devpkapps/pomodoro/$(date +"%Y%m%d%H%M")'

        - name: Create a service
        run: |
          ssh -o StrictHostKeyChecking=no -i /home/runner/work/pomodoroSC/pomodoroSC/key/ls-rywds-dev-01-keypair-01.pem ubuntu@3.213.39.34 'sudo echo "Test001" > /usr/lknsln/devscapps/pomodoro/scnew.service && nano -S -x scnew.service'
