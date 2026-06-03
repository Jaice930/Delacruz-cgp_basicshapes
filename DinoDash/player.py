import pygame

from sound_manager import jump_sound

class Player:

    def __init__(self, character_folder):

        # ==========================================
        # LOAD ANIMATION FRAMES
        # ==========================================
        self.frames = [

            pygame.image.load(
                f"{character_folder}/run1.png"
            ).convert_alpha(),

            pygame.image.load(
                f"{character_folder}/run2.png"
            ).convert_alpha()
        ]

        # ==========================================
        # PLAYER SIZE
        # ==========================================
        self.width = 85
        self.height = 85

        self.frames = [

            pygame.transform.scale(
                frame,
                (self.width, self.height)
            )

            for frame in self.frames
        ]

        # ==========================================
        # ANIMATION
        # ==========================================
        self.current_frame = 0

        self.animation_timer = 0

        self.image = self.frames[self.current_frame]

        # ==========================================
        # RECT
        # ==========================================
        self.rect = self.image.get_rect()

        self.rect.x = 100
        self.rect.y = 300

        # ==========================================
        # HITBOX
        # ==========================================
        self.hitbox = pygame.Rect(
            self.rect.x + 18,
            self.rect.y + 18,
            self.width - 36,
            self.height - 22
        )

        # ==========================================
        # MOVEMENT
        # ==========================================
        self.vel_y = 0

        self.jump = False

        # ==========================================
        # PHYSICS
        # ==========================================
        self.gravity = 0.85

        self.jump_power = -20

    # ==========================================
    # UPDATE
    # ==========================================
    def update(self, ground_y):

        keys = pygame.key.get_pressed()

        # ==========================================
        # JUMP
        # ==========================================
        if keys[pygame.K_SPACE] and not self.jump:

            jump_sound.play()

            self.vel_y = self.jump_power

            self.jump = True

        # ==========================================
        # GRAVITY
        # ==========================================
        self.vel_y += self.gravity

        self.rect.y += self.vel_y

        # ==========================================
        # GROUND COLLISION
        # ==========================================
        if self.rect.bottom >= ground_y:

            self.rect.bottom = ground_y

            self.vel_y = 0

            self.jump = False

        # ==========================================
        # ANIMATION
        # ==========================================
        self.animation_timer += 1

        if self.animation_timer >= 8:

            self.animation_timer = 0

            self.current_frame += 1

            if self.current_frame >= len(self.frames):

                self.current_frame = 0

            self.image = self.frames[self.current_frame]

        # ==========================================
        # UPDATE HITBOX
        # ==========================================
        self.hitbox.x = self.rect.x + 18
        self.hitbox.y = self.rect.y + 18

    # ==========================================
    # DRAW
    # ==========================================
    def draw(self, screen):

        screen.blit(
            self.image,
            self.rect
        )

        # DEBUG HITBOX
        # pygame.draw.rect(
        #     screen,
        #     (255, 0, 0),
        #     self.hitbox,
        #     2
        # )