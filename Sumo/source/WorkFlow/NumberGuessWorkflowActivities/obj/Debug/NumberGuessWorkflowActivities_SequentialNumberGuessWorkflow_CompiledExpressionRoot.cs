namespace NumberGuessWorkflowActivities {
    
    #line 20 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\NumberGuessWorkflowActivities\SequentialNumberGuessWorkflow .xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\NumberGuessWorkflowActivities\SequentialNumberGuessWorkflow .xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 21 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\NumberGuessWorkflowActivities\SequentialNumberGuessWorkflow .xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\NumberGuessWorkflowActivities\SequentialNumberGuessWorkflow .xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\NumberGuessWorkflowActivities\SequentialNumberGuessWorkflow .xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\NumberGuessWorkflowActivities\SequentialNumberGuessWorkflow .xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 22 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\NumberGuessWorkflowActivities\SequentialNumberGuessWorkflow .xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 23 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\NumberGuessWorkflowActivities\SequentialNumberGuessWorkflow .xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 24 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\NumberGuessWorkflowActivities\SequentialNumberGuessWorkflow .xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 1 "C:\Users\TC-14\Documents\GitHub\Sumo_SPO\Sumo\source\WorkFlow\NumberGuessWorkflowActivities\SequentialNumberGuessWorkflow .xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class SequentialNumberGuessWorkflow : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext0 = ((SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext0.ValueType___Expr0Get();
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SequentialNumberGuessWorkflow_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SequentialNumberGuessWorkflow_TypedDataContext2(locations, activityContext, true);
                }
                SequentialNumberGuessWorkflow_TypedDataContext2 refDataContext1 = ((SequentialNumberGuessWorkflow_TypedDataContext2)(cachedCompiledDataContext[1]));
                return refDataContext1.GetLocation<int>(refDataContext1.ValueType___Expr1Get, refDataContext1.ValueType___Expr1Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext2 = ((SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext3 = ((SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext4 = ((SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext4.ValueType___Expr4Get();
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SequentialNumberGuessWorkflow_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SequentialNumberGuessWorkflow_TypedDataContext2(locations, activityContext, true);
                }
                SequentialNumberGuessWorkflow_TypedDataContext2 refDataContext5 = ((SequentialNumberGuessWorkflow_TypedDataContext2)(cachedCompiledDataContext[1]));
                return refDataContext5.GetLocation<int>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext6 = ((SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SequentialNumberGuessWorkflow_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new SequentialNumberGuessWorkflow_TypedDataContext2(locations, activityContext, true);
                }
                SequentialNumberGuessWorkflow_TypedDataContext2 refDataContext7 = ((SequentialNumberGuessWorkflow_TypedDataContext2)(cachedCompiledDataContext[1]));
                return refDataContext7.GetLocation<int>(refDataContext7.ValueType___Expr7Get, refDataContext7.ValueType___Expr7Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext8 = ((SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext9 = ((SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext10 = ((SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext10.ValueType___Expr10Get();
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
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext0 = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext0.ValueType___Expr0Get();
            }
            if ((expressionId == 1)) {
                SequentialNumberGuessWorkflow_TypedDataContext2 refDataContext1 = new SequentialNumberGuessWorkflow_TypedDataContext2(locations, true);
                return refDataContext1.GetLocation<int>(refDataContext1.ValueType___Expr1Get, refDataContext1.ValueType___Expr1Set);
            }
            if ((expressionId == 2)) {
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext2 = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext3 = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext4 = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext4.ValueType___Expr4Get();
            }
            if ((expressionId == 5)) {
                SequentialNumberGuessWorkflow_TypedDataContext2 refDataContext5 = new SequentialNumberGuessWorkflow_TypedDataContext2(locations, true);
                return refDataContext5.GetLocation<int>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set);
            }
            if ((expressionId == 6)) {
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext6 = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                SequentialNumberGuessWorkflow_TypedDataContext2 refDataContext7 = new SequentialNumberGuessWorkflow_TypedDataContext2(locations, true);
                return refDataContext7.GetLocation<int>(refDataContext7.ValueType___Expr7Get, refDataContext7.ValueType___Expr7Set);
            }
            if ((expressionId == 8)) {
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext8 = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext9 = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly valDataContext10 = new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == false) 
                        && ((expressionText == "new System.Random().Next(1, MaxNumber + 1)") 
                        && (SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "Target") 
                        && (SequentialNumberGuessWorkflow_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "Guess != Target") 
                        && (SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "\"Please enter a number between 1 and \" + MaxNumber") 
                        && (SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "Guess.ToString()") 
                        && (SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "Guess") 
                        && (SequentialNumberGuessWorkflow_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "Turns +1") 
                        && (SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "Turns") 
                        && (SequentialNumberGuessWorkflow_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "Guess != Target") 
                        && (SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "Guess < Target") 
                        && (SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "Guess > MaxNumber") 
                        && (SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
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
                return new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new SequentialNumberGuessWorkflow_TypedDataContext2(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new SequentialNumberGuessWorkflow_TypedDataContext2(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new SequentialNumberGuessWorkflow_TypedDataContext2(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class SequentialNumberGuessWorkflow_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public SequentialNumberGuessWorkflow_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SequentialNumberGuessWorkflow_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SequentialNumberGuessWorkflow_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class SequentialNumberGuessWorkflow_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public SequentialNumberGuessWorkflow_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SequentialNumberGuessWorkflow_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SequentialNumberGuessWorkflow_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class SequentialNumberGuessWorkflow_TypedDataContext1 : SequentialNumberGuessWorkflow_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int Turns;
            
            protected int MaxNumber;
            
            public SequentialNumberGuessWorkflow_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SequentialNumberGuessWorkflow_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SequentialNumberGuessWorkflow_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            protected override void GetValueTypeValues() {
                this.Turns = ((int)(this.GetVariableValue((0 + locationsOffset))));
                this.MaxNumber = ((int)(this.GetVariableValue((1 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            protected override void SetValueTypeValues() {
                this.SetVariableValue((0 + locationsOffset), this.Turns);
                this.SetVariableValue((1 + locationsOffset), this.MaxNumber);
                base.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 2))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 2);
                }
                expectedLocationsCount = 2;
                if (((locationReferences[(offset + 0)].Name != "Turns") 
                            || (locationReferences[(offset + 0)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "MaxNumber") 
                            || (locationReferences[(offset + 1)].Type != typeof(int)))) {
                    return false;
                }
                return SequentialNumberGuessWorkflow_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class SequentialNumberGuessWorkflow_TypedDataContext1_ForReadOnly : SequentialNumberGuessWorkflow_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int Turns;
            
            protected int MaxNumber;
            
            public SequentialNumberGuessWorkflow_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SequentialNumberGuessWorkflow_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SequentialNumberGuessWorkflow_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            protected override void GetValueTypeValues() {
                this.Turns = ((int)(this.GetVariableValue((0 + locationsOffset))));
                this.MaxNumber = ((int)(this.GetVariableValue((1 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 2))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 2);
                }
                expectedLocationsCount = 2;
                if (((locationReferences[(offset + 0)].Name != "Turns") 
                            || (locationReferences[(offset + 0)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "MaxNumber") 
                            || (locationReferences[(offset + 1)].Type != typeof(int)))) {
                    return false;
                }
                return SequentialNumberGuessWorkflow_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class SequentialNumberGuessWorkflow_TypedDataContext2 : SequentialNumberGuessWorkflow_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int Guess;
            
            protected int Target;
            
            public SequentialNumberGuessWorkflow_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SequentialNumberGuessWorkflow_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SequentialNumberGuessWorkflow_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
                
                #line 51 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
          Target;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr1Get() {
                
                #line 51 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                return 
          Target;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr1Set(int value) {
                
                #line 51 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                
          Target = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr1Set(int value) {
                this.GetValueTypeValues();
                this.@__Expr1Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 73 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
              Guess;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr5Get() {
                
                #line 73 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                return 
              Guess;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr5Set(int value) {
                
                #line 73 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                
              Guess = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr5Set(int value) {
                this.GetValueTypeValues();
                this.@__Expr5Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 85 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
              Turns;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr7Get() {
                
                #line 85 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                return 
              Turns;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr7Set(int value) {
                
                #line 85 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                
              Turns = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr7Set(int value) {
                this.GetValueTypeValues();
                this.@__Expr7Set(value);
                this.SetValueTypeValues();
            }
            
            protected override void GetValueTypeValues() {
                this.Guess = ((int)(this.GetVariableValue((2 + locationsOffset))));
                this.Target = ((int)(this.GetVariableValue((3 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            protected override void SetValueTypeValues() {
                this.SetVariableValue((2 + locationsOffset), this.Guess);
                this.SetVariableValue((3 + locationsOffset), this.Target);
                base.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 4))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 4);
                }
                expectedLocationsCount = 4;
                if (((locationReferences[(offset + 2)].Name != "Guess") 
                            || (locationReferences[(offset + 2)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "Target") 
                            || (locationReferences[(offset + 3)].Type != typeof(int)))) {
                    return false;
                }
                return SequentialNumberGuessWorkflow_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly : SequentialNumberGuessWorkflow_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected int Guess;
            
            protected int Target;
            
            public SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public SequentialNumberGuessWorkflow_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
                
                #line 56 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
          new System.Random().Next(1, MaxNumber + 1);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr0Get() {
                
                #line 56 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                return 
          new System.Random().Next(1, MaxNumber + 1);
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr0Get() {
                this.GetValueTypeValues();
                return this.@__Expr0Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr2GetTree() {
                
                #line 62 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
        Guess != Target;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr2Get() {
                
                #line 62 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                return 
        Guess != Target;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 78 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              "Please enter a number between 1 and " + MaxNumber;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr3Get() {
                
                #line 78 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                return 
              "Please enter a number between 1 and " + MaxNumber;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 68 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              Guess.ToString();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr4Get() {
                
                #line 68 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                return 
              Guess.ToString();
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 90 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
              Turns +1;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr6Get() {
                
                #line 90 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                return 
              Turns +1;
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 97 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
              Guess != Target;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr8Get() {
                
                #line 97 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                return 
              Guess != Target;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 104 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                  Guess < Target;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr9Get() {
                
                #line 104 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                return 
                  Guess < Target;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 115 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                        Guess > MaxNumber;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr10Get() {
                
                #line 115 "C:\USERS\TC-14\DOCUMENTS\GITHUB\SUMO_SPO\SUMO\SOURCE\WORKFLOW\NUMBERGUESSWORKFLOWACTIVITIES\SEQUENTIALNUMBERGUESSWORKFLOW .XAML"
                return 
                        Guess > MaxNumber;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            protected override void GetValueTypeValues() {
                this.Guess = ((int)(this.GetVariableValue((2 + locationsOffset))));
                this.Target = ((int)(this.GetVariableValue((3 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 4))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 4);
                }
                expectedLocationsCount = 4;
                if (((locationReferences[(offset + 2)].Name != "Guess") 
                            || (locationReferences[(offset + 2)].Type != typeof(int)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "Target") 
                            || (locationReferences[(offset + 3)].Type != typeof(int)))) {
                    return false;
                }
                return SequentialNumberGuessWorkflow_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}
