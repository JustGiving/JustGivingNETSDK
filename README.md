New public SDKs for the JustGiving Consumer API for Microsoft .NET


## Improvements over the old .NET SDK

- Supports authorization via OpenId Connect (OAuth2) and HTTP Basic
- Consistent method and parameter names: they now match API resource URIs and the public documentation
- Keeps developers aware of HTTP instead of ineffectively hiding it!
- Performs extended logging of HTTP interactions for easier remote troubleshooting (no more "what's a header?")
- Cleaner, easier configuration with sensible defaults
- JSON only, no XML
- Asynchronous
- Removed support for whitelabel domains / RFL / API "versions" which don't exist
- Less code, less clutter, less maintainence

### Example:

```
var client = new JustGivingApiClient2("bafff466", new OAuthAccessToken("sdfijojweoimicew0932dnmosdf")); 
client.UseSandbox();
client.LogEverything();

var myContentFeed = await client.Accounts.GetContentFeed();

if(myContentFeed.StatusCode == HttpStatusCode.Ok)
{
  return View("ContentFeed", myContentFeed.Data);
}
