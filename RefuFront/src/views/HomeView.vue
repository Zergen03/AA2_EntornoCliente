<script setup lang="ts">
import HeroBanner from '@/components/Hero/HeroBanner.vue'
import HeroCard from '@/components/Hero/HeroCard.vue'
import JoinCard from '@/components/Join/JoinCard.vue'
import WhoWeAreImage from '@/components/WhoWeAre/WhoWeAreImage.vue'
import WhoWeAreText from '@/components/WhoWeAre/WhoWeAreText.vue'
</script>

<template>
  <main class="">
    <div class="main">
      <div>
        <HeroBanner
          backgroundImage="https://gestionyproteccionfelina.org/wp-content/uploads/2024/12/1000109656-scaled.webp"
        >
          <HeroCard></HeroCard>
        </HeroBanner>
      </div>
      <div class="Who-Container">
        <WhoWeAreImage backgroundImage="/src/assets/img/Ginger_Vega.jpg"></WhoWeAreImage>
        <WhoWeAreText></WhoWeAreText>
      </div>
      <div>
        <div class="join-text">
          <h1 class="poetsen-one-regular">Únete a nuestro equipo</h1>
          <p>
            ¿Te imaginas poder cambiar la vida de un gato con tus propias manos? En nuestra
            asociación queremos gente como tú, con ganas de echar una mano (o mejor dicho, una
            patita). No importa si tienes experiencia o si es tu primera vez: lo que cuenta es tu
            ilusión por ayudar.
          </p>
          <br />
          <p>¡Te esperamos con los brazos abiertos y algún que otro ronroneo!</p>
        </div>
      </div>
      <div class="join-images">
        <JoinCard
          backgroundImage="https://gestionyproteccionfelina.org/wp-content/uploads/2024/12/voluntario.webp"
          route="becomeVolunteer"
        ></JoinCard>
        <JoinCard
          backgroundImage="https://gestionyproteccionfelina.org/wp-content/uploads/2024/12/acogida.webp"
          btnColor="#5772ff"
        ></JoinCard>
      </div>
    </div>
  </main>
</template>

<style scoped>
/* .main {
  height: 75vh;
} */

.Who-Container {
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 2rem;
  max-width: 1200px;
  margin: 5% auto;
  padding: 0 2rem;
}

.join-text {
  max-width: 1250px;
  margin: 0 auto;
  text-align: center;
  padding: 2rem 1rem;
}

.join-images {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 3rem;
  margin-bottom: 20px;
}

@media (max-width: 960px) {
  .Who-Container {
    flex-direction: column;
    align-items: center;
    gap: 1.5rem;
    margin: 5%;
  }
}
</style>
