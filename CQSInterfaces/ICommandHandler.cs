using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskHeroes.CQSInterfaces
{
	public interface ICommandHandler<TCommand> 
		where TCommand: ICommand  
	{  
		void Handle(TCommand command);
	} 
}
