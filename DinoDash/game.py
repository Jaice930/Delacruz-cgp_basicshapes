import pygame
import random

from settings import *
from player import Player
from obstacle import Obstacle
from background import InfiniteBackground
from ui import Button
from sound_manager import *

pygame.init()

# ==========================================
# SCREEN
# ==========================================
screen = pygame.display.set_mode((WIDTH, HEIGHT))

pygame.display.set_caption(TITLE)

clock = pygame.time.Clock()

# ==========================================
# FONTS
# ==========================================
title_font = pygame.font.Font(
    "assets/fonts/game_font.ttf",
    80
)

font = pygame.font.Font(
    "assets/fonts/game_font.ttf",
    40
)

# ==========================================
# BACKGROUND
# ==========================================
background = InfiniteBackground()

# ==========================================
# PLAYER
# ==========================================
selected_character = "assets/characters/dino1"

player = Player(selected_character)

# ==========================================
# GAME VARIABLES
# ==========================================
score = 0

spawn_timer = 0

obstacles = []

game_state = "menu"

game_speed = 6

# ==========================================
# MUSIC
# ==========================================
current_music = "menu"

pygame.mixer.music.load(menu_music)

pygame.mixer.music.play(-1)

# ==========================================
# BUTTONS
# ==========================================
play_button = Button(
    "assets/buttons/play.png",
    WIDTH // 2,
    220,
    250,
    100
)

options_button = Button(
    "assets/buttons/options.png",
    WIDTH // 2,
    340,
    250,
    100
)

quit_button = Button(
    "assets/buttons/quit.png",
    WIDTH // 2,
    460,
    250,
    100
)

back_button = Button(
    "assets/buttons/back.png",
    100,
    50,
    120,
    60
)

# ==========================================
# CHARACTER SELECT IMAGES
# ==========================================
char1 = pygame.image.load(
    "assets/characters/dino1/run1.png"
).convert_alpha()

char2 = pygame.image.load(
    "assets/characters/dino2/run1.png"
).convert_alpha()

char3 = pygame.image.load(
    "assets/characters/dino3/run1.png"
).convert_alpha()

char1 = pygame.transform.scale(char1, (120, 120))
char2 = pygame.transform.scale(char2, (120, 120))
char3 = pygame.transform.scale(char3, (120, 120))

char1_rect = char1.get_rect(center=(250, 250))
char2_rect = char2.get_rect(center=(500, 250))
char3_rect = char3.get_rect(center=(750, 250))

# ==========================================
# MAIN LOOP
# ==========================================
running = True

while running:

    clock.tick(FPS)

    mouse_pos = pygame.mouse.get_pos()

    # ==========================================
    # EVENTS
    # ==========================================
    for event in pygame.event.get():

        if event.type == pygame.QUIT:

            running = False

        # ==========================================
        # MOUSE CLICK
        # ==========================================
        if event.type == pygame.MOUSEBUTTONDOWN:

            # ==========================================
            # MENU
            # ==========================================
            if game_state == "menu":

                if play_button.clicked(mouse_pos):

                    select_sound.play()

                    game_state = "character"

                elif options_button.clicked(mouse_pos):

                    select_sound.play()

                    game_state = "options"

                elif quit_button.clicked(mouse_pos):

                    running = False

            # ==========================================
            # OPTIONS
            # ==========================================
            elif game_state == "options":

                if back_button.clicked(mouse_pos):

                    select_sound.play()

                    game_state = "menu"

            # ==========================================
            # CHARACTER SELECT
            # ==========================================
            elif game_state == "character":

                if char1_rect.collidepoint(mouse_pos):

                    selected_character = (
                        "assets/characters/dino1"
                    )

                elif char2_rect.collidepoint(mouse_pos):

                    selected_character = (
                        "assets/characters/dino2"
                    )

                elif char3_rect.collidepoint(mouse_pos):

                    selected_character = (
                        "assets/characters/dino3"
                    )

                else:
                    continue

                # CREATE PLAYER
                player = Player(selected_character)

                select_sound.play()

                score = 0

                obstacles.clear()

                # ==========================================
                # GAME MUSIC
                # ==========================================
                pygame.mixer.music.stop()

                pygame.mixer.music.load(game_music)

                pygame.mixer.music.play(-1)

                current_music = "game"

                game_state = "play"

    # ==========================================
    # GAMEPLAY
    # ==========================================
    if game_state == "play":

        # SCORE
        score += 1

        # ==========================================
        # SPEED PROGRESSION
        # ==========================================
        game_speed = 6 + (score // 400)

        if game_speed > 18:

            game_speed = 18

        # ==========================================
        # GROUND HEIGHT
        # ==========================================
        ground_y = background.get_ground_y()

        # ==========================================
        # UPDATE PLAYER
        # ==========================================
        player.update(ground_y)

        # ==========================================
        # UPDATE BACKGROUND
        # ==========================================
        background.speed = game_speed

        background.update()

        # ==========================================
        # SPAWN OBSTACLES
        # ==========================================
        spawn_timer += 1

        if spawn_timer >= 80:

            spawn_timer = 0

            obstacle_image = random.choice([
                "assets/obstacles/cactus.png",
                "assets/obstacles/rock.png"
            ])

            obstacle = Obstacle(
                obstacle_image,
                ground_y
            )

            obstacle.speed = game_speed

            obstacles.append(obstacle)

        # ==========================================
        # UPDATE OBSTACLES
        # ==========================================
        for obstacle in obstacles[:]:

            obstacle.speed = game_speed

            obstacle.update()

            # REMOVE OFFSCREEN
            if obstacle.rect.right < 0:

                obstacles.remove(obstacle)

            # ==========================================
            # COLLISION
            # ==========================================
            if player.hitbox.colliderect(obstacle.rect):

                hit_sound.play()

                score = 0

                obstacles.clear()

                # ==========================================
                # MENU MUSIC
                # ==========================================
                pygame.mixer.music.stop()

                pygame.mixer.music.load(menu_music)

                pygame.mixer.music.play(-1)

                current_music = "menu"

                game_state = "menu"

    # ==========================================
    # SIMPLE MENU BACKGROUND
    # ==========================================
    if game_state == "menu":

        screen.fill((20, 20, 20))

    elif game_state == "options":

        screen.fill((25, 25, 25))

    elif game_state == "character":

        screen.fill((30, 30, 30))

    elif game_state == "play":

        background.draw(screen)

    # ==========================================
    # MENU SCREEN
    # ==========================================
    if game_state == "menu":

        title = title_font.render(
            "DINO DASH",
            True,
            WHITE
        )

        title_rect = title.get_rect(
            center=(WIDTH // 2, 90)
        )

        screen.blit(title, title_rect)

        play_button.draw(screen)

        options_button.draw(screen)

        quit_button.draw(screen)

    # ==========================================
    # OPTIONS SCREEN
    # ==========================================
    elif game_state == "options":

        title = font.render(
            "OPTIONS",
            True,
            WHITE
        )

        title_rect = title.get_rect(
            center=(WIDTH // 2, 100)
        )

        screen.blit(title, title_rect)

        info = font.render(
            "Music & Sounds Enabled",
            True,
            WHITE
        )

        info_rect = info.get_rect(
            center=(WIDTH // 2, 250)
        )

        screen.blit(info, info_rect)

        back_button.draw(screen)

    # ==========================================
    # CHARACTER SELECT
    # ==========================================
    elif game_state == "character":

        title = font.render(
            "SELECT YOUR DINO",
            True,
            WHITE
        )

        title_rect = title.get_rect(
            center=(WIDTH // 2, 100)
        )

        screen.blit(title, title_rect)

        screen.blit(char1, char1_rect)
        screen.blit(char2, char2_rect)
        screen.blit(char3, char3_rect)

    # ==========================================
    # PLAY SCREEN
    # ==========================================
    elif game_state == "play":

        # PLAYER
        player.draw(screen)

        # OBSTACLES
        for obstacle in obstacles:

            obstacle.draw(screen)

        # SCORE
        score_text = font.render(
            f"Score: {score}",
            True,
            WHITE
        )

        screen.blit(score_text, (20, 20))

        # SPEED
        speed_text = font.render(
            f"Speed: {game_speed}",
            True,
            WHITE
        )

        screen.blit(speed_text, (20, 70))

    # ==========================================
    # UPDATE DISPLAY
    # ==========================================
    pygame.display.update()

# ==========================================
# QUIT
# ==========================================
pygame.quit()