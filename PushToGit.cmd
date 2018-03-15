echo off
echo Start initialization to git...
git init
echo Adding current directory to git...
git add .
echo Committing to git :-
git commit -m "First Commit"
echo Pushing to git :-
git push -u origin master
echo Pushing Done...!!
exit