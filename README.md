[![buildall][buildall-img]][buildall-url]
[![codecov][codecov-img]][codecov-url]

# Mini Juego de rol con C#

Crear una juego de rol donde dos grupos de personajes se enfrenten hasta
que solo uno sea el ganador del trono.

## Generación de personaje

El resultado de la batalla se obtendrá por un sistema de combate basado
en turnos y por un cálculo matemático/probabilístico utilizando las
habilidades de cada personaje

El/la ganador/a de la contienda continuará para una próxima batalla
mientras que el otro será eliminado de la partida.

### Datos

- Tipo
- Nombre
- Apodo
- Fecha de Nacimiento
- Edad (entre 0 y 300)
- Salud (100)

### Características

- Velocidad (1 a 10)
- Destreza (1 a 5)
- Fuerza (1 a 10)
- Nivel (1 a 10)
- Armadura (1 a 10)

## Generación de valores aleatorios

1. Hacer un proceso que cargue los datos de un personaje
1. Hacer un proceso que muestre los datos de un personaje
#

1. Hacer un proceso que cargue las características de un personaje
1. Hacer un proceso que muestre las características de un personaje

## Mecánica del Combate

Elija 2 personajes para que compitan entre ellos. Cada uno tendrá 3
ataques que irán debilitando al oponente. Al final de dichas rondas el
que mejor salud tenga será declarado ganador (puede haber empate).

El personaje que pierda la batalla será eliminado de la lista y el que
gane será beneficiado con una mejora en sus habilidades que puede ser
aleatorio o no, por ejemplo +10 en salud o de un 5% a un 10% de Fuerza,
etc.

La forma de valorar la efectividad del ataque es la siguiente:

### Valores de ataque

- **Poder de Disparo**: Haga el producto de Destreza * Fuerza * Nivel
  del personaje que ataca (PD)
- **Efectividad de Disparo**: Genere un valor aleatorio de 1 a 100.
  Considerarlo como valor porcentual (ED)
- **Valor de Ataque**: Al Poder de Disparo lo multiplico por la
  Efectividad de Disparo (VA)

### Valores de defensa

- **Poder de Defensa**: Haga el producto de Armadura * Velocidad del
  personaje que defiende (PDEF)

### Resultado del enfrentamiento

- **Máximo Daño Provocable**: 50000 (MDP)
- **Daño Provocado**: Valor de Ataque * Efectividad de Disparo - Poder de
  Defensa todo eso dividido por el máximo daño provocado (50000) y a todo
  eso lo multiplico por 100 → ((VA*EP)-PDEF)/MDP)*100
- **Actualizar salud del personaje** que se defiende restándole a Salud
  el Daño provocado.

### Mecánica del Combate

Al final de los enfrentamientos deberá quedar un único personaje en pie.
Este será declarado el ganador y será merecedor del **Trono de Hierro**.
Haga los honores correspondientes mostrando sus datos por pantalla y un
mensaje destacado.

[buildall-img]: https://github.com/rpgrca/MiniRpg2022/actions/workflows/net.yml/badge.svg
[buildall-url]: https://github.com/rpgrca/Katas/actions/workflows/net.yml
[codecov-img]: https://codecov.io/gh/rpgrca/MiniRpg2022/branch/main/graph/badge.svg?token=pib55fULVQ
[codecov-url]: https://codecov.io/gh/rpgrca/MiniRpg2022
