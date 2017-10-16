# Server-side-App
an ASP.NET MVC project (MVC5, .NET Framework 4.5 4.6.1, C#)
• There is a default action, Index, for the Home controller, that displays a welcome
message, personalized for a registered user as before.

• There is an action, Register, for the Account controller, that allows a user to
register a cookie with their userid and ADA preferences, as before.

• Upload. This allows a registered user to upload an image to the server. This page should save not just the image file, but
also a caption and description specified by the user, as well as the date that the photograph was taken. To simplify things, the user should also be required to provide an image identifier, with this identifier used to name the image file, and the image information file, on the server. Again, define an action (annotated with HttpGet) for displaying an empty form, and another action of the same name (annotated with HttpPost) for processing the input. When an upload is complete, redisplay the upload page with a success message and with the input fields reset to empty. If there are validation errors, then the original data should be retained in the form, to allow the user to make amendments.

• Another action, Details, processes the contents of this form, when it is submitted by the user. With an image identifier as a query string parameter, this action returns a page that displays the specified image. This should display the image and the information about that image: its caption and description, the date the photograph was taken, and the user who uploaded the image. If there is no image with that identifier on the Web site, then display the original form with a message that that identifier does not exist, allowing the user to enter another image identifier.
