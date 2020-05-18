﻿using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Utilidades
{
    public class SendEmailUtils
    {
        public static void SendEmail(string to, string nombreEmpleado, string id)
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Empresa PlanningDB", "planningdb95@gmail.com"));
            
            mailMessage.To.Add(new MailboxAddress(nombreEmpleado, to));
            mailMessage.Subject = "Cambia la clave";
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = @"<!DOCTYPE html>
<html lang='en' dir='ltr'>

<head>
  <meta http-equiv = 'Content-Type' content='text/html; charset=utf-8'>
  <!--[if !mso]><!-->
 
   <meta http-equiv='X-UA-Compatible' content='IE=edge'>
      
        <!--< ![endif]-->
      
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
         
           <title></title>
         
           <!--[if !mso]><!-->
          
            <style type='text/css'>
               @font-face {
                font-family:'flama-condensed';
                font-weight: 100;
            src: url('http://assets.vervewine.com/fonts/FlamaCond-Medium.eot');
            src: url('http://assets.vervewine.com/fonts/FlamaCond-Medium.eot?#iefix') format('embedded-opentype'),
                    url('http://assets.vervewine.com/fonts/FlamaCond-Medium.woff') format('woff'),
                    url('http://assets.vervewine.com/fonts/FlamaCond-Medium.ttf') format('truetype');
            }
            @font-face {
                font-family: 'Muli';
                font-weight: 100;
            src: url('http://assets.vervewine.com/fonts/muli-regular.eot');
            src: url('http://assets.vervewine.com/fonts/muli-regular.eot?#iefix') format('embedded-opentype'),
                    url('http://assets.vervewine.com/fonts/muli-regular.woff2') format('woff2'),
                    url('http://assets.vervewine.com/fonts/muli-regular.woff') format('woff'),
                    url('http://assets.vervewine.com/fonts/muli-regular.ttf') format('truetype');
            }
          .address-description a {
            color: #000000 ; text-decoration: none;}
          @media(max-device-width: 480px) {
            .vervelogoplaceholder {
                    height: 83px;
                    }
                }
  </style >
  <!--< ![endif]-->
  <!--[if (gte mso 9)|(IE)]>
  
      <style type='text/css'>
   
           .address-description a {
                color: #000000 ; text-decoration: none;}
        table { border-collapse: collapse; }
    </style >
    <![endif]-->
</head >

<body bgcolor='#e1e5e8' style='margin-top:0 ;margin-bottom:0 ;margin-right:0 ;margin-left:0 ;padding-top:0px;padding-bottom:0px;padding-right:0px;padding-left:0px;background-color:#e1e5e8;'>
    
                 <center style='width:100%;table-layout:fixed;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;background-color:#e1e5e8;'>
                
                    <div style='max-width:600px;margin-top:0;margin-bottom:0;margin-right:auto;margin-left:auto;'>
                 
                       <table align='center' cellpadding='0' style='border-spacing:0;font-family:'Muli',Arial,sans-serif;color:#333333;Margin:0 auto;width:100%;max-width:600px;'>
                      
                              <tbody>
                      
                                <tr>
                      
                                  <td align ='center' class='vervelogoplaceholder' height='143' style='padding-top:0;padding-bottom:0;padding-right:0;padding-left:0;height:143px;vertical-align:middle;' valign='middle'><span class='sg-image' data-imagelibrary='%7B%22width%22%3A%22160%22%2C%22height%22%3A34%2C%22alt_text%22%3A%22Verve%20Wine%22%2C%22alignment%22%3A%22%22%2C%22border%22%3A0%2C%22src%22%3A%22https%3A//marketing-image-production.s3.amazonaws.com/uploads/79d8f4f889362f0c7effb2c26e08814bb12f5eb31c053021ada3463c7b35de6fb261440fc89fa804edbd11242076a81c8f0a9daa443273da5cb09c1a4739499f.png%22%2C%22link%22%3A%22%23%22%2C%22classes%22%3A%7B%22sg-image%22%3A1%7D%7D'><a href = '#' target='_blank'>
              <img alt='Verve Wine' height='34' src='https://marketing-image-production.s3.amazonaws.com/uploads/79d8f4f889362f0c7effb2c26e08814bb12f5eb31c053021ada3463c7b35de6fb261440fc89fa804edbd11242076a81c8f0a9daa443273da5cb09c1a4739499f.png' style='border-width: 0px; width: 160px; height: 34px;' width='160'></a></span></td>
          </tr>
          <!-- Start of Email Body-->
          <tr>
            <td class='one-column' style='padding-top:0;padding-bottom:0;padding-right:0;padding-left:0;background-color:#ffffff;'>
              
  
                <table style='border-spacing:0;' width='100%'>
                <tbody>
                  <tr>
                    <td align='center' class='inner' style='padding-top:15px;padding-bottom:15px;padding-right:30px;padding-left:30px;' valign='middle'><span class='sg-image' data-imagelibrary='%7B%22width%22%3A%22255%22%2C%22height%22%3A93%2C%22alt_text%22%3A%22Forgot%20Password%22%2C%22alignment%22%3A%22%22%2C%22border%22%3A0%2C%22src%22%3A%22https%3A//marketing-image-production.s3.amazonaws.com/uploads/35c763626fdef42b2197c1ef7f6a199115df7ff779f7c2d839bd5c6a8c2a6375e92a28a01737e4d72f42defcac337682878bf6b71a5403d2ff9dd39d431201db.png%22%2C%22classes%22%3A%7B%22sg-image%22%3A1%7D%7D'><img alt='Forgot Password' class='banner' height='93' src='https://marketing-image-production.s3.amazonaws.com/uploads/35c763626fdef42b2197c1ef7f6a199115df7ff779f7c2d839bd5c6a8c2a6375e92a28a01737e4d72f42defcac337682878bf6b71a5403d2ff9dd39d431201db.png' style='border-width: 0px; margin-top: 30px; width: 255px; height: 93px;' width='255'></span></td>
                  </tr>
                  <tr>
                    <td class='inner contents center' style='padding-top:15px;padding-bottom:15px;padding-right:30px;padding-left:30px;text-align:left;'>
                      <center>
                        <p class='h1 center' style='Margin:0;text-align:center;font-family:'flama-condensed','Arial Narrow',Arial;font-weight:100;font-size:30px;Margin-bottom:26px;'>Restaurar password?</p>
                        <!--[if (gte mso 9)|(IE)]><![endif]-->

                        <p class='description center' style='font-family:'Muli','Arial Narrow',Arial;Margin:0;text-align:center;max-width:320px;color:#a1a8ad;line-height:24px;font-size:15px;Margin-bottom:10px;margin-left: auto; margin-right: auto;'><span style = 'color: rgb(161, 168, 173); font-family: Muli, &quot;Arial Narrow&quot;, Arial; font-size: 15px; text-align: center; background-color: rgb(255, 255, 255);' > Click en el botón de abajo para restablercer su password.</span></p>
                        <!--[if (gte mso 9)|(IE)]><br>&nbsp;<![endif]--><span class='sg-image' data-imagelibrary='%7B%22width%22%3A%22260%22%2C%22height%22%3A54%2C%22alt_text%22%3A%22Reset%20your%20Password%22%2C%22alignment%22%3A%22%22%2C%22border%22%3A0%2C%22src%22%3A%22https%3A//marketing-image-production.s3.amazonaws.com/uploads/c1e9ad698cfb27be42ce2421c7d56cb405ef63eaa78c1db77cd79e02742dd1f35a277fc3e0dcad676976e72f02942b7c1709d933a77eacb048c92be49b0ec6f3.png%22%2C%22link%22%3A%22%23%22%2C%22classes%22%3A%7B%22sg-image%22%3A1%7D%7D'><a href = 'http://localhost:4200/cambio-password?id={0}' target='_blank'><img alt = 'Reset your Password' height='54' src='https://marketing-image-production.s3.amazonaws.com/uploads/c1e9ad698cfb27be42ce2421c7d56cb405ef63eaa78c1db77cd79e02742dd1f35a277fc3e0dcad676976e72f02942b7c1709d933a77eacb048c92be49b0ec6f3.png' style='border-width: 0px; margin-top: 30px; margin-bottom: 50px; width: 260px; height: 54px;' width='260'></a></span>
                        <!--[if (gte mso 9)|(IE)]><br>&nbsp;<![endif]--></center>
                    </td>
                  </tr>
                </tbody>
              </table>
              <!--[if (gte mso 9)|(IE)]>
                    </td></tr></table>
                    </center>
                    <![endif]-->
            </td>
          </tr>
          <!-- End of Email Body-->
          <!-- whitespace -->

          <!--[if gte mso 9]>
</td></tr></table>
</center>
<![endif]-->


</body>
</html>
".Replace("{0}",id)
            };

            SmtpClient smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, false);
            smtp.Authenticate("planningdb95@gmail.com", "1037593481");
            smtp.Send(mailMessage);
        }

    }
}