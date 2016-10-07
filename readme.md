# LetsRest
HttpClient wrapper for Restful API aiming for making things easier

## NOTE: this project is still under development. Do not use it for production yet.

### Usage
```c#
Rest.For("http://jsonplaceholder.typicode.com/posts/1")
  .Get()
  .String();
```
