using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using System.IO;
using System.Web.Services;
using MonitoreUniversal.Entidades;
using MonitoreoUniversal.Negocio;

namespace MonitoreoUniversal
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : System.Web.Services.WebService
    {

        PersonalNegocio personalNegocio = new PersonalNegocio();


        [OperationContract]
        [WebGet(UriTemplate = "/GetPersonal", ResponseFormat = WebMessageFormat.Json)]
        public List<Personal> getAllPersonal()
        {
            List<Personal> list = new List<Personal>();
            try
            {
                list = personalNegocio.getAllPersonal();
            }
            catch (Exception e)
            {
            }
            return list;
        }
    }
}
