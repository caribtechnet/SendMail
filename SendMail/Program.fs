// Learn more about F# at http://fsharp.org

open System
open System.Net;
open System.Net.Mail;
open System.Net.Mime;

//You can update this code into a commandline tool

[<EntryPoint>]
let main argv =    
    try
        let mySmtpClient = new SmtpClient("smtp.gmail.com")
        mySmtpClient.EnableSsl <- true
        mySmtpClient.Host<- "smtp.gmail.com"
        mySmtpClient.Port <- 587
        mySmtpClient.UseDefaultCredentials <- false
        let basicAuthenticationInfo = new  System.Net.NetworkCredential("your_account@gmail.com", "your_account_app_password")

        mySmtpClient.Credentials <- basicAuthenticationInfo
        let from = new MailAddress("someone@somedomain.com", "TestFromName")
        let myto = new MailAddress("your_account@gmail.com", "TestToName")
        let myMail = new System.Net.Mail.MailMessage(from, myto)
        myMail.Subject <- "Test message"
        myMail.SubjectEncoding <- System.Text.Encoding.UTF8
        myMail.Body <- "<b>Test Mail</b><br>using <b>HTML</b>."
        myMail.BodyEncoding <- System.Text.Encoding.UTF8
        mySmtpClient.Send(myMail)
        ignore <| Ok("The email was sent, I think!")
    with 
        |exp -> 
        ignore <| Error (System.String.Format("Unable to send the email! {0}" , exp.Message))
    


    0 // return an integer exit code
