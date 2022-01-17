# CORS
- The full name of CORS is Cross Origin Resource Sharing.
- It is a W3C standard that allows a server to make cross-domain calls from the specified domains.
- This security in the software term is called the same-origin policy and does not allow a suspensive site attack for reading sensitive data from another site.
- When we are using multipe domain applications which is reqired to call from one domain to other domainin . Then in this case if the browser supports CORS, it sets the headers automatically for cross-origin requests.
- If all the things will work as expected with the server, then the server adds "Access-Control-Allow-Origin" header in the response.
- To setup the CORS we need to  install Nuget package: Microsoft.AspNetCore.Cors.

### Implementation
 There are  three ways to enable CORS:
- Middleware using a named policy or default policy.
- Using endpoint routing.
- Using [EnableCors] attribute.
