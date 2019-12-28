
heroku login -i "turcu.98.stefanel@gmail.com" "Manimani1!"

git checkout master
git remote add heroku https://heroku:dd8968e0-c302-4c5d-8332-53de7e8c4eb6@git.heroku.com/cityride-app.git
git add .
git commit -m "CI tool commit"
git push heroku master