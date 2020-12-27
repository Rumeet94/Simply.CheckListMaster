using System;

namespace Simply.CheckListMaster.BLL.Exceptions {
	public class MediatorException : Exception {
		public MediatorException(string message)
			: base(message) {
		}
	}
}
