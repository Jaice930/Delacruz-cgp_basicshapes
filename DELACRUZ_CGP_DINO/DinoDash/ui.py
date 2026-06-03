import pygame

class Button:
    def __init__(self, image, x, y, width=250, height=100):

        self.image = pygame.image.load(image).convert_alpha()

        # Resize button
        self.image = pygame.transform.scale(self.image, (width, height))

        self.rect = self.image.get_rect(center=(x, y))

    def draw(self, screen):
        screen.blit(self.image, self.rect)

    def clicked(self, pos):
        return self.rect.collidepoint(pos)