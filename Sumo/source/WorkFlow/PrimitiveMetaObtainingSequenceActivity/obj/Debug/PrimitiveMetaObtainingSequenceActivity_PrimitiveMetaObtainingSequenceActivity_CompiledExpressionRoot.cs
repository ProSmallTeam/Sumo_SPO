namespace PrimitiveMetaObtainingSequenceActivity {
    
    #line 18 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\PrimitiveMetaObtainingSequenceActivity\PrimitiveMetaObtainingSequenceActivity.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\PrimitiveMetaObtainingSequenceActivity\PrimitiveMetaObtainingSequenceActivity.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 19 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\PrimitiveMetaObtainingSequenceActivity\PrimitiveMetaObtainingSequenceActivity.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\PrimitiveMetaObtainingSequenceActivity\PrimitiveMetaObtainingSequenceActivity.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\PrimitiveMetaObtainingSequenceActivity\PrimitiveMetaObtainingSequenceActivity.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\PrimitiveMetaObtainingSequenceActivity\PrimitiveMetaObtainingSequenceActivity.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 20 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\PrimitiveMetaObtainingSequenceActivity\PrimitiveMetaObtainingSequenceActivity.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 21 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\PrimitiveMetaObtainingSequenceActivity\PrimitiveMetaObtainingSequenceActivity.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 22 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\PrimitiveMetaObtainingSequenceActivity\PrimitiveMetaObtainingSequenceActivity.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\PrimitiveMetaObtainingSequenceActivity\PrimitiveMetaObtainingSequenceActivity.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class PrimitiveMetaObtainingSequenceActivity : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
        private System.Activities.Activity rootActivity;
        
        private object dataContextActivities;
        
        private bool forImplementation = true;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string GetLanguage() {
            return "C#";
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public object InvokeExpression(int expressionId, System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext) {
            if ((this.rootActivity == null)) {
                this.rootActivity = this;
            }
            if ((this.dataContextActivities == null)) {
                this.dataContextActivities = PrimitiveMetaObtainingSequenceActivity_TypedDataContext1_ForReadOnly.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = PrimitiveMetaObtainingSequenceActivity_TypedDataContext1_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new PrimitiveMetaObtainingSequenceActivity_TypedDataContext1_ForReadOnly(locations, activityContext, true);
                }
                PrimitiveMetaObtainingSequenceActivity_TypedDataContext1_ForReadOnly valDataContext0 = ((PrimitiveMetaObtainingSequenceActivity_TypedDataContext1_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext0.ValueType___Expr0Get();
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = PrimitiveMetaObtainingSequenceActivity_TypedDataContext1.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new PrimitiveMetaObtainingSequenceActivity_TypedDataContext1(locations, activityContext, true);
                }
                PrimitiveMetaObtainingSequenceActivity_TypedDataContext1 refDataContext1 = ((PrimitiveMetaObtainingSequenceActivity_TypedDataContext1)(cachedCompiledDataContext[1]));
                return refDataContext1.GetLocation<int>(refDataContext1.ValueType___Expr1Get, refDataContext1.ValueType___Expr1Set, expressionId, this.rootActivity, activityContext);
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public object InvokeExpression(int expressionId, System.Collections.Generic.IList<System.Activities.Location> locations) {
            if ((this.rootActivity == null)) {
                this.rootActivity = this;
            }
            if ((expressionId == 0)) {
                PrimitiveMetaObtainingSequenceActivity_TypedDataContext1_ForReadOnly valDataContext0 = new PrimitiveMetaObtainingSequenceActivity_TypedDataContext1_ForReadOnly(locations, true);
                return valDataContext0.ValueType___Expr0Get();
            }
            if ((expressionId == 1)) {
                PrimitiveMetaObtainingSequenceActivity_TypedDataContext1 refDataContext1 = new PrimitiveMetaObtainingSequenceActivity_TypedDataContext1(locations, true);
                return refDataContext1.GetLocation<int>(refDataContext1.ValueType___Expr1Get, refDataContext1.ValueType___Expr1Set);
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == false) 
                        && ((expressionText == "Counter + 1") 
                        && (PrimitiveMetaObtainingSequenceActivity_TypedDataContext1_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "Counter") 
                        && (PrimitiveMetaObtainingSequenceActivity_TypedDataContext1.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            expressionId = -1;
            return false;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<string> GetRequiredLocations(int expressionId) {
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Linq.Expressions.Expression GetExpressionTreeForExpression(int expressionId, System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) {
            if ((expressionId == 0)) {
                return new PrimitiveMetaObtainingSequenceActivity_TypedDataContext1_ForReadOnly(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new PrimitiveMetaObtainingSequenceActivity_TypedDataContext1(locationReferences).@__Expr1GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class PrimitiveMetaObtainingSequenceActivity_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public PrimitiveMetaObtainingSequenceActivity_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public PrimitiveMetaObtainingSequenceActivity_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public PrimitiveMetaObtainingSequenceActivity_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal static object GetDataContextActivitiesHelper(System.Activities.Activity compiledRoot, bool forImplementation) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetDataContextActivities(compiledRoot, forImplementation);
            }
            
            internal static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
            }
            
            public static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 0))) {
                    return false;
                }
                expectedLocationsCount = 0;
                return true;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class PrimitiveMetaObtainingSequenceActivity_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public PrimitiveMetaObtainingSequenceActivity_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public PrimitiveMetaObtainingSequenceActivity_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public PrimitiveMetaObtainingSequenceActivity_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal static object GetDataContextActivitiesHelper(System.Activities.Activity compiledRoot, bool forImplementation) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetDataContextActivities(compiledRoot, forImplementation);
            }
            
            internal static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
            }
            
            public static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 0))) {
                    return false;
                }
                expectedLocationsCount = 0;
                return true;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class PrimitiveMetaObtainingSequenceActivity_TypedDataContext1 : PrimitiveMetaObtainingSequenceActivity_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int Counter;
            
            public PrimitiveMetaObtainingSequenceActivity_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public PrimitiveMetaObtainingSequenceActivity_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public PrimitiveMetaObtainingSequenceActivity_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr1GetTree() {
                
                #line 46 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\PRIMITIVEMETAOBTAININGSEQUENCEACTIVITY\PRIMITIVEMETAOBTAININGSEQUENCEACTIVITY.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
          Counter;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr1Get() {
                
                #line 46 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\PRIMITIVEMETAOBTAININGSEQUENCEACTIVITY\PRIMITIVEMETAOBTAININGSEQUENCEACTIVITY.XAML"
                return 
          Counter;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr1Set(int value) {
                
                #line 46 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\PRIMITIVEMETAOBTAININGSEQUENCEACTIVITY\PRIMITIVEMETAOBTAININGSEQUENCEACTIVITY.XAML"
                
          Counter = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr1Set(int value) {
                this.GetValueTypeValues();
                this.@__Expr1Set(value);
                this.SetValueTypeValues();
            }
            
            protected override void GetValueTypeValues() {
                this.Counter = ((int)(this.GetVariableValue((0 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            protected override void SetValueTypeValues() {
                this.SetVariableValue((0 + locationsOffset), this.Counter);
                base.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 1))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 1);
                }
                expectedLocationsCount = 1;
                if (((locationReferences[(offset + 0)].Name != "Counter") 
                            || (locationReferences[(offset + 0)].Type != typeof(int)))) {
                    return false;
                }
                return PrimitiveMetaObtainingSequenceActivity_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class PrimitiveMetaObtainingSequenceActivity_TypedDataContext1_ForReadOnly : PrimitiveMetaObtainingSequenceActivity_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int Counter;
            
            public PrimitiveMetaObtainingSequenceActivity_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public PrimitiveMetaObtainingSequenceActivity_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public PrimitiveMetaObtainingSequenceActivity_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr0GetTree() {
                
                #line 51 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\PRIMITIVEMETAOBTAININGSEQUENCEACTIVITY\PRIMITIVEMETAOBTAININGSEQUENCEACTIVITY.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
          Counter + 1;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr0Get() {
                
                #line 51 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\PRIMITIVEMETAOBTAININGSEQUENCEACTIVITY\PRIMITIVEMETAOBTAININGSEQUENCEACTIVITY.XAML"
                return 
          Counter + 1;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr0Get() {
                this.GetValueTypeValues();
                return this.@__Expr0Get();
            }
            
            protected override void GetValueTypeValues() {
                this.Counter = ((int)(this.GetVariableValue((0 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 1))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 1);
                }
                expectedLocationsCount = 1;
                if (((locationReferences[(offset + 0)].Name != "Counter") 
                            || (locationReferences[(offset + 0)].Type != typeof(int)))) {
                    return false;
                }
                return PrimitiveMetaObtainingSequenceActivity_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}
