use teste

drop table usuario
drop table pontuacao


create table pontuacao(
				CodPontuacao int identity(1, 1) primary key,
				NomeJogador varchar (25),
				Pontuacao int 
)


select NomeJogador Nome, Pontuacao Pontos
from pontuacao
order by Pontos DESC

select * from pontuacao


