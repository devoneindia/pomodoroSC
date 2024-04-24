# pomodoroSC
Time Tracking App
      - name: Make Key Read only Step 2
        run: sudo chmod 0400 /home/runner/work/pomodoroPK/pomodoroPK/Key/ls-rywds-dev-01-keypair-01.pem
        - name: Make Key Read only Step 3 - Verify
        run: pwd && ls -al /home/runner/work/pomodoroPK/pomodoroPK/Key
        - name: Install SSH
        run: sudo apt-get install openssh-client -y
      - name: Create Server Target Folder
        run: ssh -o StrictHostKeyChecking=no -i /home/runner/work/pomodoroPK/pomodoroPK/Key/ls-rywds-dev-01-keypair-01.pem  ubuntu@3.213.39.34 'mkdir -p /usr/devpkapps/pomodoro/$(date +"%Y%m%d%H%M")'
      - name: Copy Server files to EC2 instance
        run: scp -o StrictHostKeyChecking=no -r -i /home/runner/work/pomodoroPK/pomodoroPK/Key/ls-rywds-dev-01-keypair-01.pem ./publish/* 'ubuntu@3.213.39.34:/usr/devpkapps/pomodoro/$(date +"%Y%m%d%H%M")'
      - name: Create Client Target Folder
        run: ssh -o StrictHostKeyChecking=no -i /home/runner/work/pomodoroPK/pomodoroPK/Key/ls-rywds-dev-01-keypair-01.pem  ubuntu@3.213.39.34 'mkdir -p /var/www/html/devpkapps/pomodoro/$(date +"%Y%m%d%H%M")'
      - name: Copy Client files to EC2 instance
        run: scp -o StrictHostKeyChecking=no -r -i /home/runner/work/pomodoroPK/pomodoroPK/Key/ls-rywds-dev-01-keypair-01.pem /home/runner/work/pomodoroPK/pomodoroPK/pomodoro.client/dist/pomodoro.client/browser/* 'ubuntu@3.213.39.34:/var/www/html/devpkapps/pomodoro/$(date +"%Y%m%d%H%M")'