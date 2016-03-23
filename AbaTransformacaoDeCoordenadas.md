Versão 1.0.0.6

# Funções da aba 'Transformações de Coordenadas' #

## Grau / Minuto / Seg `<->` Decimal ##

Converte coordenadas na notação Grau (º), Minuto (') e segundo ('') para graus decimais, e vice versa.

## Geodésica `<->` UTM ##

Converte um par de coordenadas geodésicas (entrada em graus decimais) para UTM, e vice versa, com a possibilidade de escolha dos seguintes _data_ (incluindo alguns usados em Portugal, Europa e América do Norte):
  * WGS-1984
  * SIRGAS-2000
  * SAD-1969
  * Córrego Alegre
  * Lisboa (Hayford)
  * Lisboa (Bessel)
  * Datum 1973
  * ED-1950
  * WGS-1972
  * NAD-1983

A implementação dos cálculos foi feita seguindo o memorial de cálculo de Steven Dutch, disponível em http://www.uwgb.edu/dutchs/usefuldata/utmformulas.htm e http://www.uwgb.edu/dutchs/usefuldata/UTMConversions1.xls