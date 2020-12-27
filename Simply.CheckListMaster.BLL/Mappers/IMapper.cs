namespace Simply.CheckListMaster.BLL.Mappers {
	public interface IMapper<TIn, TOut> {
		TOut Map(TIn value);

		TIn BackMap(TOut value);
	}
}
