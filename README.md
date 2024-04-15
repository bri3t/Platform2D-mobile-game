# Platform2D-mobile-game

El juego consiste en reunir las 15 monedas que estan repartidas por el mapa, tratando de evitar ser golpeado por los enemigos y tratando de matarlos disparandoles o saltandoles encima para lograr que sea mas facil poder recoletar las monedas.

## Funcionamiento General del Juego y cómo jugar

El juego es un plataformero 2D donde el jugador controla a John, un personaje que debe avanzar a través de diferentes enemigos para recolectar las 15 monedas. A continuación se describe la mecánica general del juego:

Inicio del juego: Ejecuta el juego y selecciona 'Start Game' en el menú principal.

- **Movimiento**: John puede moverse hacia la izquierda y hacia la derecha con las teclas de flecha o AD correspondientes, o bien con los botones por pantalla (Android).
- **Salto**: John puede saltar presionando la tecla 'W' o pulsando el boton por pantalla de salto, que le permite esquivar enemigos y alcanzar plataformas elevadas.
- **Disparo**: Al presionar la tecla 'Espacio' o bien pulsando el boton por pantalla de disparo, John dispara a los enemigos frente a él. Las balas tienen una trayectoria recta y desaparecen al impactar.
- **Vidas y Puntuación**: John comienza el juego con un número limitado de vidas (4). Puede perder vidas al ser golpeado por enemigos o al caerse del mapa, y puede recuperarlas recogiendo ítems de vida que aparecen en el nivel.

### Puzzle
Para poder pasarte el juego, deberas saltar encima de esta palmera, y avanzar a las siguientes dos plataformas situadas arriba para colectar la moneda especial roja.
<br>
<img src="https://github.com/bri3t/Platform2D-mobile-game/assets/120582826/5cc7f77d-4625-428a-9d93-cd944449f3ed" alt="puzzle" width="400" height="250">


## Animaciones
-> Assets/Animations
##### Quien?   -   Nombre Animacion   (cuando?)
- **John**: "JohnIdle" (standard), "JohnRun" (cuando corre), JohnDead (cuando muere)
- **Monedas**: "Coin" (standard) , "RedCoin" (standard para la moneda roja)
- **Enemigos**: "GruntAnimation" (standard), "GruntDeath" (cuando muere)
- **Bullet**: "BulletAnimation" (animacion de la bala al ser disparada)

## Sources

## Instalación

Para instalar el juego, sigue estos pasos:

1. Clona el repositorio a tu máquina local usando:
   ```bash
   git clone URL_DEL_REPOSITORIO
