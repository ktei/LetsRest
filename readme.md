# LetsRest
HttpClient wrapper for Restful API aiming to make things easier

## NOTE: this project is still under development. Do not use it for production yet.

### Usage
```c#
Lets.Call("http://...").Then().Get().ReceiveString();

Lets.Call("http://...").Then().PostAsJson().ReceiveJson<MyClass>();

Lets.Call("http://...")
    .WithOAuthBearerToken("mytoken")
    .Then().PostAsJson().ReceiveJson<MyClass>();
```
