import pygame
import random
from settings import *

class Obstacle:

    def __init__(self, image, ground_y):

        # ==========================================
        # LOAD IMAGE
        # ==========================================
        self.image = pygame.image.load(
            image
        ).convert_alpha()

        # ==========================================
        # BIGGER SIZE
        # ==========================================
        size = random.randint(75, 95)

        self.image = pygame.transform.scale(
            self.image,
            (size, size)
        )

        # ==========================================
        # RECT
        # ==========================================
        self.rect = self.image.get_rect()

        self.rect.x = WIDTH + random.randint(150, 350)

        # ==========================================
        # GROUND ALIGNMENT
        # ==========================================
        self.rect.bottom = ground_y

        # ==========================================
        # SPEED
        # ==========================================
        self.speed = 6

    # ==========================================
    # UPDATE
    # ==========================================
    def update(self):

        self.rect.x -= self.speed

    # ==========================================
    # DRAW
    # ==========================================
    def draw(self, screen):

        screen.blit(
            self.image,
            self.rect
        )