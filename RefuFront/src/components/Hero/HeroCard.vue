<template>
  <div class="card">
    <h1 class="poetsen-one-regular">
      Espazio felino <br />
      Shanti
    </h1>
    <p>
      ¿Eres amante de los gatos, quieres disfrutar de ellos y además ayudarles?
      Con tu visita al EspaZio contribuirás a mantener la asociación y también,
      a aumentar los rescates de gatos que sobreviven en las calles.
    </p>
    <v-btn class="button" rounded="xl" elevation="4" size="large">Reservar</v-btn>
  </div>
</template>

<style scoped>
.card {
  background-color: white;
  border-radius: 1rem;
  padding: 2rem;
  box-shadow: 0 8px 24px rgba(0, 0, 0, 0.15);
  width: 100%;
}

.button {
  margin-top: 1.5rem;
  background-color: #f47a22;
  color: white;
}

.button:hover {
  background-color: #b35715 !important;
  color: white;
}
</style>
