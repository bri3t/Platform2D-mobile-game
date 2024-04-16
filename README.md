# Platform2D-mobile-game

El juego consiste en reunir las 15 monedas que están repartidas por el mapa, tratando de evitar ser golpeado por los enemigos y tratando de matarlos disparándoles o saltándoles encima para lograr que sea más fácil poder recolectar las monedas.

## Funcionamiento General del Juego y cómo jugar

El juego es un plataformas 2D donde el jugador controla a John, un personaje que debe avanzar a través de diferentes enemigos para recolectar las 15 monedas. A continuación se describe la mecánica general del juego:

Inicio del juego: Ejecuta el juego y selecciona 'Start Game' en el menú principal.

- **Movimiento**: John puede moverse hacia la izquierda y hacia la derecha con las teclas de flecha o AD correspondientes, o bien con los botones por pantalla (Android).
- **Salto**: John puede saltar presionando la tecla 'W' o pulsando el botón por pantalla de salto, que le permite esquivar enemigos y alcanzar plataformas elevadas.
- **Disparo**: Al presionar la tecla 'Espacio' o bien pulsando el botón por pantalla de disparo, John dispara a los enemigos frente a él. Las balas tienen una trayectoria recta y desaparecen al impactar.
- **Vidas y Puntuación**: John comienza el juego con un número limitado de vidas (4). Puede perder vidas al ser golpeado por enemigos o al caerse del mapa, y puede recuperarlas recogiendo ítems de vida que aparecen en el nivel.
- **Matar enemigos**: Los enemigos tienen 2 puntos de vida, pueden morir al recibir 2 balas de John, o que Jhon les caiga encima de la cabeza.

## Puzzle
Para poder pasarte el juego, deberás saltar encima de esta palmera, y avanzar a las siguientes dos plataformas situadas arriba para colectar la moneda especial roja.
<br>
<img src="https://github.com/bri3t/Platform2D-mobile-game/assets/120582826/5cc7f77d-4625-428a-9d93-cd944449f3ed" alt="puzzle" width="400" height="250">

## Animaciones
-&gt; Assets/Animations
##### Quien? - Nombre Animación (cuando?)
- **John**: "JohnIdle" (standard), "JohnRun" (cuando corre), JohnDead (cuando muere)
- **Monedas**: "Coin" (standard) , "RedCoin" (standard para la moneda roja)
- **Enemigos**: "GruntAnimation" (standard), "GruntDeath" (cuando muere)
- **Bullet**: "BulletAnimation" (animación de la bala al ser disparada)

## Sources
Listado de enlaces a todas las fuentes de información, sprites, assets o documentación externa que he utilizado para desarrollar el juego.

- [Unity Documentación Oficial](https://unity.com/docs)
- [SpriteSheets principal](https://didigameboy.itch.io/jambo-jungle-free-sprites-asset-pack)
- [Assets coins](https://laredgames.itch.io/gems-coins-free)
- [Assets corazones](https://nicolemariet.itch.io/pixel-heart-animation-32x32-16x16-freebie)
- [Botones](https://void1gaming.itch.io/pixel-buttons)
- [Fuente](https://www.dafont.com/es/search.php?q=Minecraft)
- Sonidos extra
   - [sound](https://elements.envato.com/es/sound-effects/coin)
   - [sound](https://www.fesliyanstudios.com/royalty-free-music/downloads-c/8-bit-music/6)
- [Wallpaper menú](https://wallpaper.mob.org/pc/image/artistic-pixel_art-mountain-waterfall-1035817.html#google_vignette)

## Cómo Instalar y Ejecutar

### Descargar el Código Fuente
Para obtener el código fuente del juego, primero necesitarás clonar el repositorio de GitHub. Puedes hacer esto usando Git. Si no tienes Git instalado en tu ordenador, puedes descargarlo desde [git-scm.com](https://git-scm.com/downloads).

#### (Windows)
Abre una terminal y ejecuta el siguiente comando para clonar el repositorio:
1. Clona el repositorio a tu máquina local usando:
```bash
   git clone https://github.com/bri3t/Platform2D-mobile-game.git
   cd Platform2D-mobile-game
```
## Abre el Proyecto en Unity

Una vez que tengas el código fuente en tu máquina local, abre Unity Hub. Si aún no tienes Unity Hub, puedes descargarlo desde [Unity Download Page](https://unity.com/download).

En Unity Hub, ve a la pestaña 'Projects', luego haz clic en 'ADD' y selecciona la carpeta donde clonaste el proyecto. Esto añadirá el proyecto a tu lista de proyectos de Unity. Haz clic en el nombre del proyecto para abrirlo en el editor de Unity.
Construir y Ejecutar el Juego

Para construir y ejecutar el juego en tu dispositivo móvil, sigue estos pasos en el editor de Unity:
1. Conecta tu dispositivo móvil a la computadora a través de USB. Asegúrate de que esté configurado para permitir la depuración por USB.
2. En Unity, ve a File &gt; Build Settings.
3. Selecciona la plataforma de destino (Android) en la lista y haz clic en Switch Platform.
4. Para Android, asegúrate de que Google Android Project esté marcado si quieres editar el proyecto con Android Studio.
5. Haz clic en Build. Esto compilará el juego y generará un fichero apk que podrás instalar en un dispositivo android.
6. ¡Jugar!

## Compatibilidad
Para hacer este proyecto he usado:
- Unity: 2022.3.21f1
- Microsoft Visual Studio: 2022 17.9.6
- Java: "17.0.9" 2023-10-17 LTS

## Lenguaje de programación usado
- C#

## Paquetes unity usados

![libs](https://github.com/bri3t/Platform2D-mobile-game/assets/120582826/bf2a03e8-98ee-4bf6-88d7-e55d4d154aae)

