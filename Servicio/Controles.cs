using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Servicio
{
    public static class Controles
    {
           

    public static void ActualizarControles(BE.Idioma idioma, Page pagina)
        {
            foreach (Control c in pagina.Controls)
            {
                //switch (c.GetType().ToString())
                //{
                //    case "System.Web.UI.WebControls.Label":
                //        Label myLabel = (Label)c;
                //        var nombreLabel = from i in idioma.Controles
                //                    where i.Id == c.ID
                //                    select i.Valor.First();
                //        myLabel.Text = nombreLabel.ToString();
                //        break;
                //    case "System.Web.UI.WebControls.Button":
                //        Button myButton = (Button)c;
                //        var nombreButton = from i in idioma.Controles
                //                    where i.Id == c.ID
                //                    select i.Valor.First();
                //        myButton.Text = nombreButton.ToString();
                //        break;
                //    case "System.Web.UI.HtmlControls.HtmlForm":
                //        ActualizarControles(idioma, c);
                //        break;
                //    default:
                //        break;
                //} 
                if (c is Label)
                {
                    Label myLabel = (Label)c;
                    //var nombreLabel = from i in idioma.Controles
                    //            where i.Id == c.ID
                    //            select i.Valor.First();
                    //myLabel.Text = nombreLabel.ToString();
                    try
                    {
                        myLabel.Text = idioma.Controles.First(s => s.Id == c.ID).Valor;
                    }
                    catch { }
                }
                else if (c is Button)
                {
                    Button myButton = (Button)c;
                    try
                    {
                        myButton.Text = idioma.Controles.First(s => s.Id == c.ID).Valor;
                    }
                    catch { }
                    //var nombreButton = from i in idioma.Controles
                    //            where i.Id == c.ID
                    //            select i.Valor.First();
                    //myButton.Text = nombreButton.ToString();
                }
                else if (c is HyperLink)
                {
                    HyperLink myHyperlink = (HyperLink)c;
                    try
                    {
                        myHyperlink.Text = idioma.Controles.First(s => s.Id == c.ID).Valor;
                    }
                    catch { }
                }
                else
                {
                    ActualizarControles(idioma, c);
                }
            }            
        }

        public static void ActualizarControles(BE.Idioma idioma, Control pagina)
        {
            foreach (Control c in pagina.Controls)
            {
                if (c is Label)
                {
                    Label myLabel = (Label)c;
                    //var nombreLabel = from i in idioma.Controles
                    //                  where i.Id == c.ID
                    //                  select i.Valor.First();
                    //myLabel.Text = nombreLabel.ToString();
                    try
                    {
                        myLabel.Text = idioma.Controles.First(s => s.Id == c.ID).Valor;
                    }
                    catch { }                  
                }
                else if (c is Button)
                {
                    Button myButton = (Button)c;
                    try
                    {
                        myButton.Text = idioma.Controles.First(s => s.Id == c.ID).Valor;
                    }
                    catch { }
                    //var nombreButton = from i in idioma.Controles
                    //                   where i.Id == c.ID
                    //                   select i.Valor.First();
                    //myButton.Text = nombreButton.ToString();
                }
                else if (c is HyperLink)
                {
                    HyperLink myHyperlink = (HyperLink)c;
                    try
                    {
                        myHyperlink.Text = idioma.Controles.First(s => s.Id == c.ID).Valor;
                    }
                    catch { }
                }
                else
                {
                    ActualizarControles(idioma, c);
                }

                //if (c is Label)
                //{
                //    Label myLabel = (Label)c;
                //    var nombreLabel = from i in idioma.Controles
                //                      where i.Id == c.ID
                //                      select i.Valor;
                //    myLabel.Text = nombreLabel.FirstOrDefault();
                //}
                //switch (c.GetType().ToString())
                //{
                //    case "System.Web.UI.WebControls.Label":
                //        Label myLabel = (Label)c;                        
                //        var nombreLabel = from i in idioma.Controles
                //                          where i.Id == c.ID
                //                          select i.Valor;
                //        myLabel.Text = nombreLabel.FirstOrDefault();
                //        break;
                //    case "System.Web.UI.WebControls.Button":
                //        Button myButton = (Button)c;
                //        var nombreButton = from i in idioma.Controles
                //                           where i.Id == c.ID
                //                           select i.Valor;
                //        myButton.Text = nombreButton.FirstOrDefault();
                //        break;
                //    case "System.Web.UI.WebControls.TextBox":
                //        TextBox myTextBox = (TextBox)c;
                //        var nombreTextBox = from i in idioma.Controles
                //                           where i.Id == c.ID
                //                           select i.Valor;                        
                //        myTextBox.Attributes.Add("placeholder", nombreTextBox.FirstOrDefault());
                //        break;
                //    default:
                //        break;
                //}
            }
        }
    }
}
