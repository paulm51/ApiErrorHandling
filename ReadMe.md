## Options

##### Developer Exception Page

---
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

---

If bnot enabled and without anything in place will return a 500 with EMPTY response body to the client

#### Error Handling Endpoint

###### Startup

       if (env.IsDevelopment())
        {
            //app.UseDeveloperExceptionPage();  // Will return the complete exception in the response body
            app.UseExceptionHandler("/error-local-development");   // Will return the complete exception wrapped in Problem Details in the response body
        }
        else
        {
            app.UseExceptionHandler("/error");
        }

###### ErrorController
    [HttpGet]
    [Route("/error")]
    public IActionResult Error() => Problem(); // return Problem Details response



#### References

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-5.0
