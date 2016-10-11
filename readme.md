# LetsRest
HttpClient wrapper for Restful API aiming to make things easier

## NOTE: This library is new baby, which only has limited features. 

### Usage
```c#
Lets.Call("http://...").Then().Get().ReceiveString();

Lets.Call("http://...").Then().PostAsJson().ReceiveJson<MyClass>();

Lets.Call("http://...")
    .WithOAuthBearerToken("mytoken")
    .Then().PostAsJson().ReceiveJson<MyClass>();
```
