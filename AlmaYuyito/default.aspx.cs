using LibYuyiyo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibYuyiyo.Helper;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace AlmaYuyito
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
            litTitulo.Text = "";
           
            
            
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {

            creaGraficoIngresos();

            string script2 = "crearChartBar();";

            ScriptManager.RegisterStartupScript(this, GetType(), "alerta", script2, true);
        }


        public void creaGraficoIngresos()
        {
            string data1 = "[700, 445, 483, 503, 689, 692, 634,700, 445, 483, 503, 689]";
            string data2 = "{"
                              + "  labels: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],"
                              + "  datasets: [{"
                              + "      data: [750, 445, 483, 503, 689, 692, 634,700, 445, 483, 503, 689],"
                              + "      backgroundColor: '#0059b6',"
                              + "      borderColor: '#007bff',"
                              + "      borderWidth: 1, "
                              + "      pointBackgroundColor: '#007bff' "
                              + " }]"
                          + "}";
            string data3 = "{"
                              + "   type: 'line',"
                              + "   data: " + data2 + ","
                              + "   options: {"
                              + "       scales: {"
                              + "           yAxes: [{"
                              + "               ticks: {  "
                              + "                   beginAtZero: false,"
                              + "                   callback: function (value, index, values) {"
                              + "                       return float2dollar(value);"
                              + "                   }"
                              + "               }"
                              + "           }]"
                              + "       },"
                              + "       legend: {"
                              + "           display: false"
                              + "       }"
                              + "   }"
                          + "}";

            var jobject = JsonConvert.DeserializeObject(data2);

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert("+JObject.Parse(data2)["labels"]+")", true);

            JObject json = new JObject();
            
            string script = "crearChartLine();";

            ScriptManager.RegisterStartupScript(this, GetType(), "alerta", script, true);

            
            //script = "crearChartLine();";

            //ScriptManager.RegisterStartupScript(this, GetType(), "alerta", script, true);
        }
    }
}