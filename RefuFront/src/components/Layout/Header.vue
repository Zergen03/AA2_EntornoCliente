<script setup lang="ts">
import { ref } from 'vue'
import { RouterLink } from 'vue-router'

const drawer = ref(false)
</script>

<template>
  <div class="header">
    <div class="header-content rounded-xl">
      <div class="logo">
        <v-img :width="100" aspect-ratio="1/1" cover src="https://gestionyproteccionfelina.org/wp-content/uploads/2024/07/gyp_logo.webp"></v-img>
      </div>

      <div class="d-none d-md-flex">
        <nav>
          <RouterLink to="/">Home</RouterLink>
          <RouterLink to="/quienes_somos">Quienes Somos</RouterLink>
          <RouterLink to="/hazte_voluntario">Hazte Voluntario</RouterLink>
          <RouterLink to="/logIn">LogIn</RouterLink>
        </nav>
      </div>

      <v-btn icon class="d-md-none burguer-icon" @click="drawer = !drawer">
        <v-icon>mdi-menu</v-icon>
      </v-btn>
    </div>
  </div>

  <v-navigation-drawer
    v-model="drawer"
    temporary
    location="left"
  >
    <v-list>
      <v-list-item link>
        <RouterLink to="/">Home</RouterLink>
      </v-list-item>
      <v-list-item link>
        <RouterLink to="/quienes_somos">Quienes Somos</RouterLink>
      </v-list-item>
      <v-list-item link>
        <RouterLink to="/hazte_voluntario">Hazte Voluntario</RouterLink>
      </v-list-item>
      <v-list-item link>
        <RouterLink to="/logIn">LogIn</RouterLink>
      </v-list-item>
    </v-list>
  </v-navigation-drawer>
</template>

<style setup>
.header {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  padding: 2rem 1rem;
}

.header-content {
  background-color: #fff5ef;
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  padding: 1rem;
  position: relative;
}

.header > * {
  margin: 0 2%;
}

nav {
  display: flex;
  justify-content: space-between;
}

nav > * {
  padding: 1rem;
}

.burguer-icon{
    background-color: #f47a22;
    color: #ffffff;
}
.burguer-icon:hover{
    background-color: #b35715;
}
</style>
