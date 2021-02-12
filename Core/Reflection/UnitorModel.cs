﻿using dnlib.DotNet;
using Il2CppInspector.Model;
using Il2CppInspector.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitor.Core.Reflection
{
    public class UnitorModel
    {
        public List<TypeDef> ProcessedMonoTypes { get; } = new List<TypeDef>();
        public List<TypeInfo> ProcessedIl2CppTypes { get; } = new List<TypeInfo>();
        public Dictionary<TypeDef, UnitorType> MonoTypeMatches { get; } = new Dictionary<TypeDef, UnitorType>();
        public Dictionary<TypeInfo, UnitorType> Il2CppTypeMatches { get; } = new Dictionary<TypeInfo, UnitorType>();

        public List<string> Namespaces { get; } = new List<string>();
        public List<UnitorType> Types { get; } = new List<UnitorType>();
        public TypeModel TypeModel { get; set; }
        public AppModel AppModel { get; set; }

        public ModuleDef ModuleDef { get; set; }

        public static UnitorModel FromTypeModel(TypeModel typeModel, EventHandler<string> statusCallback = null)
        {
            UnitorModel model = new UnitorModel();
            model.Types.AddRange(typeModel.Types.Where(
                t => !t.Assembly.ShortName.Contains("System") &&
                !t.Assembly.ShortName.Contains("Mono") &&
                !t.Assembly.ShortName.Contains("UnityEngine") &&
                t.Assembly.ShortName != "mscorlib.dll"
                ).ToUnitorTypeList(model, statusCallback: statusCallback).Where(t => !t.IsEmpty));
            model.Namespaces.AddRange(model.Types.Select(t => t.Namespace).Distinct());
            model.TypeModel = typeModel;
            statusCallback?.Invoke(model, "Creating AppModel");
            model.AppModel = new AppModel(typeModel);
            return model;
        }
        public static UnitorModel FromModuleDef(ModuleDef moduleDef, EventHandler<string> statusCallback = null)
        {
            UnitorModel model = new UnitorModel();
            model.Types.AddRange(moduleDef.Types.ToUnitorTypeList(model, statusCallback: statusCallback));
            model.Namespaces.AddRange(moduleDef.Types.Select(t => t.Namespace.String).Distinct());
            model.ModuleDef = moduleDef;
            return model;
        }
        public void Add(UnitorModel model)
        {
            Types.AddRange(model.Types);
            Namespaces.Clear();
            Namespaces.AddRange(Types.Select(t => t.Namespace).Distinct());
        }
    }
}