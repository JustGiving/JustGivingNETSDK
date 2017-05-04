New public SDKs for the JustGiving Consumer API for Microsoft .NET

### QuickStart:

```
var string appId = "e488ce85";
var client = new JustGivingApiClient(appId);

//or, if you want to use methods requiring authentication
//var authenticatedClient = new JustGivingApiClient(appId, new BasicCredential(email, password));
//var oauthClient = new JustGivingApiClient(appId, applicationKey, new OAuthAccessToken(accessToken));

client.UseProduction();
client.LogEverything();

var donations = await client.Fundraising.GetFundraisingPageDonations("pageShortName",1,20);
```
