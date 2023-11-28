using System.Net.Mail;

public  class Correos{
public string Para{get; set;}="";
public string Asunto{get; set;}="";
public string Contenido {get; set;}="";
public void Enviar(){
MailMessage correo=new MailMessage();
correo.From=new MailAddress("sancheztenoriomaximiliano3@gmail.com",null,System.Text.Encoding.UTF8);
correo.To.Add(this.Para);
correo.Subject=this.Asunto;
correo.Body=this.Contenido;
correo.IsBodyHtml=true;
correo.Priority=MailPriority.Normal;
SmtpClient smtp= new SmtpClient();
smtp.UseDefaultCredentials=false;
smtp.Host="smtp.gmail.com";
smtp.Port =587;
 smtp.EnableSsl=true;
smtp.Credentials = new System.Net.NetworkCredential("sancheztenoriomaximiliano3@gmail.com", "vuzd siye pgme kamj");//Cuenta de correo
smtp.Send(correo);
}
}
