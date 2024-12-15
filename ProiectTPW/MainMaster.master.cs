using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainMaster : System.Web.UI.MasterPage
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            clock.Text = DateTime.Now.ToString();
            img1.ImageUrl = "~/Images/img1.jpg";
            img2.ImageUrl = "~/Images/img2.jpg";
        }

    }

    protected void timer_Tick1(object sender, EventArgs e)
    {

        string var = img2.ImageUrl.ToString();
        if (var == "~/Images/img1.jpg")
            img2.ImageUrl = "~/Images/img2.jpg";
        if (var == "~/Images/img2.jpg")
            img2.ImageUrl = "~/Images/img3.jpg";
        if (var == "~/Images/img3.jpg")
            img2.ImageUrl = "~/Images/img1.jpg";

        Random random = new Random();
        int i = random.Next(1, 3);
        img1.ImageUrl = "~/Images/img" + i.ToString() + ".jpg";
        clock.Text = DateTime.Now.ToString();
    }
}

