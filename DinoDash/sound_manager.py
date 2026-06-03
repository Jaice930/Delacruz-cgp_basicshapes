import pygame

pygame.mixer.init()

# ==========================================
# SOUND EFFECTS
# ==========================================
jump_sound = pygame.mixer.Sound(
    "assets/sounds/jump.wav"
)

hit_sound = pygame.mixer.Sound(
    "assets/sounds/hit.wav"
)

select_sound = pygame.mixer.Sound(
    "assets/sounds/select.wav"
)

# ==========================================
# VOLUME
# ==========================================
jump_sound.set_volume(0.5)
hit_sound.set_volume(0.5)
select_sound.set_volume(0.5)

# ==========================================
# MUSIC FILES
# ==========================================
menu_music = "assets/sounds/menu_music.mp3"

game_music = "assets/sounds/game_music.mp3"