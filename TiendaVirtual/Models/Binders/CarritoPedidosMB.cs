using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Controllers;

namespace TiendaVirtual.Models.Binders
{
    public class CarritoPedidosMB: IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            CarritoPedidos cart = (CarritoPedidos)controllerContext.HttpContext.Session["KEY"];
            if (cart == null)
            {
                cart = new CarritoPedidos();
                controllerContext.HttpContext.Session["KEY"] = cart;
            }
            return cart;
        }
    }
}