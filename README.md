# ids-hasura-auth-problem
IdS4 + Hasura authorization problem demo program

## How to run

1. Build IdS4

```
docker build -t rulebook-auth -f Dockerfile.web .
```
   
2. Run IdS4

```
heroku create -s container
heroku container:push web -a polar-refuge-51031 --recursive
heroku container:release web -a polar-refuge-51031
```

3. Run Hasura

```
heroku addons:create -a serene-basin-12094 heroku-postgresql:hobby-dev
heroku create -s container 
heroku container:push web -a serene-basin-12094 --recursive
heroku container:release web -a serene-basin-12094
```

4. Reproduce issue

