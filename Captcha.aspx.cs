using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;

public partial class Captcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //setting font to captcha text
        Font f = new Font("Comic Sans MS", 30, FontStyle.Strikeout);
        // image width and height
        Bitmap b = new Bitmap(200, 100);

        Graphics g = Graphics.FromImage(b);

        //setting background color
        g.Clear(Color.White);

        //Strin should be Random
        String CaptchaString = generateRandomString();
        //store captchaString in session so we can Retrive it from any page
        Session.Add("CAPTCHA", CaptchaString);

        g.DrawString(CaptchaString, f, Brushes.Blue, 10, 10);

        Response.ContentType = "Image/GIF";

        b.Save(Response.OutputStream, ImageFormat.Gif);

        //Optional
        f.Dispose();
        b.Dispose();
        g.Dispose();
    }
    public String generateRandomString()
    {
        String result = "";
        //Remove Confussing Characters
        String str = "b,B,C,D,E,d,e,g,4,5,6,h,i,n,K,L,M,p,q,r,s,t,v,w,x,y,z,1,3,7,G,H,J,N,O,P,Q,R,T,8,9,A,F,U,V,W,k,l,m,X,Y,Z";
        String[] arr = str.Split(',');

        //to generate random String
        Random r = new Random();
        //for generating 5 character String
        for (int i = 0; i < 5; i++)
        {

            int num = r.Next(0, arr.Length);//r.Next(0,no. of characters);
            result += arr[num];
        }
        return result;
    }
}