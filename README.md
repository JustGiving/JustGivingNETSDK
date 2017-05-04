# .NET SDK for the JustGiving API

### QuickStart:

```powershell
PM> Install-Package JustGivingNETSDK
```

```csharp
var string appId = "e488ce85";
var client = new JustGivingApiClient(appId);

//or, if you want to use methods requiring authentication
//var basicAuthenticationClient = new JustGivingApiClient(appId, new BasicCredential(email, password));
//var oauthClient = new JustGivingApiClient(appId, applicationKey, new OAuthAccessToken(accessToken));

client.UseProduction();
client.LogEverything();

//If you need to set a proxy, do so like this
//client.UseProxy(new WebProxy()); 

var myAccountDetails = await client.Accounts.RetrieveAccount();

var donations = await client.Fundraising.GetFundraisingPageDonations("pageShortName",1,20);
```


# Also see
* [JustGiving API Developer Portal](http://developer.justgiving.com)
[If you're trying to make donations using JustGiving](https://justgivingdeveloper.zendesk.com/hc/en-us/sections/201202061-Simple-Donation-Integration-SDI-)
* [Config file for Postman that has collections of our http endpoints. ](https://github.com/JustGiving/JustGiving.Api.Tools.Postman)
