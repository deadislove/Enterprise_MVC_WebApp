using Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DesginPatterns.Interpreter;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Interpreter;
using System.Reflection;
using System.Collections;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.Interpreter
{
    public class InterpreterServices<T1, T2> : IInterpreter<T1, T2 >, IDisposable where T1 : class where T2: IEnumerable
    {
        private object _obj;
        private string[] strArr;
        private readonly char[] charArr = new char[] {' ', '/', '-' };        

        private IGenericTypeRepository<T1> _repo;
        private List<IAbstractExpression> ExpresssionList;

        public InterpreterServices(IGenericTypeRepository<T1> repo)
        {
            _repo = repo;
            DataAccess();
        }

        private void DataAccess()
        {
            _obj = _repo.GetAll().Result;
            ExpresssionList = new List<IAbstractExpression>();
        }

        public IEnumerable<T> DefaultData<T>() where T : class
        {
            try
            {
                return _obj as IEnumerable<T>;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
        }

        public T2 Expression(IEnumerable<T1> obj, Context context)
        {
            try
            {
                if (!string.IsNullOrEmpty(context.Expression))
                {
                    PropertyInfo props;
                    Type type;
                    List<InterpreterDto> respList = new List<InterpreterDto>();                    

                    strArr = context.Expression.Split(charArr);
                    AddExpression(strArr);

                    switch (obj is null)
                    {
                        case true:

                            (_obj as List<T1>).ForEach(data => {
                                type = data.GetType();
                                props = type.GetProperty("date") ?? data.GetType().GetProperty("Date");
                                context.Date = Convert.ToDateTime(props.GetValue(data));

                                LayoutExpression(context);

                                respList.Add(new InterpreterDto() {
                                    ID = (int)type.GetProperty("ID").GetValue(data),
                                    Name = (string)type.GetProperty("Name").GetValue(data),
                                    Age = (int)type.GetProperty("Age").GetValue(data),
                                    Date = context.Expression
                                });
                            });                            
                            break;
                        case false:
                            (obj as List<T1>).ForEach(data => {
                                type = data.GetType();
                                props = type.GetProperty("date") ?? data.GetType().GetProperty("Date");
                                context.Date = Convert.ToDateTime(props.GetValue(data));

                                LayoutExpression(context);

                                respList.Add(new InterpreterDto()
                                {
                                    ID = (int)type.GetProperty("ID").GetValue(data),
                                    Name = (string)type.GetProperty("Name").GetValue(data),
                                    Age = (int)type.GetProperty("Age").GetValue(data),
                                    Date = context.Expression
                                });
                            });
                            break;
                    }

                    return (T2)respList.AsEnumerable();
                }

                return (dynamic)null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
            
        }

        public T2 Expression2<T>(IEnumerable<T1> obj, Context context) where T : InterpreterDto, new()
        {
            try
            {
                if (!string.IsNullOrEmpty(context.Expression))
                {
                    PropertyInfo props;
                    Type type;
                    ICollection<T> respList = new List<T>();
                    
                    strArr = context.Expression.Split(charArr);
                    AddExpression(strArr);

                    switch (obj is null)
                    {
                        case true:

                            (_obj as List<T1>).ForEach(data => {
                                type = data.GetType();
                                props = type.GetProperty("date") ?? data.GetType().GetProperty("Date");
                                context.Date = Convert.ToDateTime(props.GetValue(data));

                                LayoutExpression(context);

                                respList.Add(new T
                                {
                                    ID = (int)type.GetProperty("ID").GetValue(data),
                                    Name = (string)type.GetProperty("Name").GetValue(data),
                                    Age = (int)type.GetProperty("Age").GetValue(data),
                                    Date = context.Expression
                                });
                            });
                            break;
                        case false:
                            (obj as List<T1>).ForEach(data => {
                                type = data.GetType();
                                props = type.GetProperty("date") ?? data.GetType().GetProperty("Date");
                                context.Date = Convert.ToDateTime(props.GetValue(data));

                                LayoutExpression(context);

                                respList.Add(new T
                                {
                                    ID = (int)type.GetProperty("ID").GetValue(data),
                                    Name = (string)type.GetProperty("Name").GetValue(data),
                                    Age = (int)type.GetProperty("Age").GetValue(data),
                                    Date = context.Expression
                                });
                            });
                            break;
                    }

                    return (T2)respList.AsEnumerable();
                }

                return (dynamic)null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
        }

        private void AddExpression(string[] strArr)
        {
            try
            {
                foreach (var ExpressionItem in strArr)
                {
                    switch (ExpressionItem)
                    {
                        case "dd":
                        case "DD":
                            ExpresssionList.Add(new DayExpression());
                            break;
                        case "mm":
                        case "MM":
                            ExpresssionList.Add(new MonthExpression());
                            break;
                        case "yyyy":
                        case "YYYY":
                            ExpresssionList.Add(new YearExpression());
                            break;
                    }
                }
                ExpresssionList.Add(new SeparatorExpression());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
        }

        private string LayoutExpression( Context context)
        {
            try
            {
                foreach (var item in ExpresssionList)
                {
                    item.Evaluate(context);
                }

                return context.Expression;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects). 
                    strArr = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~InterpreterServices()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        
        #endregion
    }
}
