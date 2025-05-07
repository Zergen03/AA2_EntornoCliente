<template>
  <v-footer class="pa-6" color="primary">
    <v-container>
      <v-row>
        <!-- Redes sociales -->
        <v-col cols="12" md="4">
          <h3 class="font-weight-bold white--text">Síguenos<br>en nuestras redes</h3>
          <v-row class="mt-4" justify="start">
            <v-col cols="auto" v-for="icon in socialIcons" :key="icon.icon">
              <v-btn :icon="icon.icon" size="large" variant="outlined" color="white" class="rounded-circle" />
            </v-col>
          </v-row>
        </v-col>

        <!-- Espacio vacío al centro -->
        <v-col cols="12" md="4"></v-col>

        <!-- Botón de adopción alineado a la derecha -->
        <v-col cols="12" md="4" class="d-flex flex-column align-end justify-center text-right">
          <h3 class="font-weight-bold white--text">No compres</h3>
            <h2 class="adopta">Adopta</h2>
        </v-col>
      </v-row>
    </v-container>
  </v-footer>
</template>

<script setup>
const socialIcons = [
  { icon: 'mdi-facebook' },
  { icon: 'mdi-instagram' },
  { icon: 'mdi-whatsapp' },
]
</script>

<style scoped>
.adopta{
  background-color: white;
  color: #f47a22;
  padding: 5px 15px;
  border-radius: 10%;
  font-weight: bold;

}
</style>