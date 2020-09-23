1) Modo Online
-Para utilizar o webservice da ViaCEP, utilizei e modifiquei alguns aspectos do projeto encontrado no seguinte repositório: https://github.com/guibranco/ViaCEP
-Deixei a parte que comunica com o webservice como um projeto separado.
-Sobrescrevi o método ToString para retornar uma string formatada que exiba, linha por linha, as informações do Endereço consultado.
-Deixei o salvamento como algo opcional do usuário, entretanto é só remover o botão Salvar e realizar a chamada do método de mesmo nome para que o salvamento seja automático a cada pesquisa.

2) Modo Offline
-O projeto que abri do Xamarin Forms já tinha uma página totalmente pronta com essa funcionalidade, foi necessário apenas modificá-la para atender as necessidades específicas deste projeto.

3) Evitar Duplicidade de dados no banco local
-Feito conforme especificado

4) Exibir o número de CEPs
-Na tela de pesquisa é informado quantos CEPs o sistema possui salvo em seu banco de dados.
