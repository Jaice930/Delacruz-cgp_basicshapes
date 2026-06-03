import pygame
from settings import *

class InfiniteBackground:

    def __init__(self):

        # ==========================================
        # LOAD JUNGLE BACKGROUND
        # ==========================================
        self.background = pygame.image.load(
            "assets/backgrounds/jungle.png"
        ).convert()

        # ==========================================
        # SCALE BACKGROUND
        # ==========================================
        self.background = pygame.transform.scale(
            self.background,
            (2019, HEIGHT)
        )

        # ==========================================
        # SCROLL SETTINGS
        # ==========================================
        self.scroll = 0

        self.speed = 5

        # ==========================================
        # GROUND HEIGHT
        # ==========================================
        self.ground_y = 395

    # ==========================================
    # GET GROUND Y
    # ==========================================
    def get_ground_y(self):

        return self.ground_y

    # ==========================================
    # UPDATE
    # ==========================================
    def update(self):

        self.scroll -= self.speed

        # RESET LOOP
        if abs(self.scroll) > self.background.get_width():

            self.scroll = 0

    # ==========================================
    # DRAW
    # ==========================================
    def draw(self, screen):

        # FIRST IMAGE
        screen.blit(
            self.background,
            (self.scroll, 0)
        )

        # SECOND IMAGE
        screen.blit(
            self.background,
            (self.scroll + self.background.get_width(), 0)
        )