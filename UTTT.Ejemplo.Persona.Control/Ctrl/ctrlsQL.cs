﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UTTT.Ejemplo.Persona.Control.Ctrl
{
    public class ctrlSQL
    {
        private readonly Regex ValidationSql = new Regex(@"('(''|[^'])*')|(\b(ALTER|alter|Alter|CREATE|create|Create|DELETE|delete|Delete|DROP|drop|Drop|EXEC(UTE){0,1}|exec(ute){0,1}|Exec(ute){0,1}|INSERT( +INTO){0,1}|insert( +into){0,1}|Insert( +into){0,1}|MERGE|merge|Merge|SELECT|Select|select|UPDATE|update|Update|UNION( +ALL){0,1}|union( +all){0,1}|Union( +all){0,1})\b)");
        private readonly Regex Validationhtml = new Regex(@"<.*?>|&.*?;");
        public bool sqlInjectionValida(String _informacion, ref String _mensaje, String _etiquetaReferente, ref System.Web.UI.WebControls.TextBox _control)
        {
            bool isMatch = this.ValidationSql.IsMatch(_informacion);
            if (isMatch)
            {
                _mensaje = "F por el SQL inyeccion " + _etiquetaReferente.Replace(":", "");
                _control.Focus();
            }
            return isMatch;
        }
        public bool htmlInjectionValida(String _informacion, ref String _mensaje, String _etiquetaReferente, ref System.Web.UI.WebControls.TextBox _control)
        {
            bool isMatch = this.Validationhtml.IsMatch(_informacion);
            if (isMatch)
            {
                _mensaje = "F por el HTML inyeccion " + _etiquetaReferente.Replace(":", "");
                _control.Focus();
            }
            return isMatch;
        }
    }
}