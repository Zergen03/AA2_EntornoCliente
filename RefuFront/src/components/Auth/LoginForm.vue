<script setup lang="ts">
import { useUserStore } from '@/stores/userStore';

const store = useUserStore()
store.fetchAll()
</script>

<template>
    <div>
        <h1>USERS</h1>
        <div v-for="user in store.users" key="users.id">

        </div>
    </div>
    <!-- <form @submit.prevent="handleLogin">
      <AuthInput v-model="email" label="Email" />
      <AuthInput v-model="password" label="Password" type="password" />
      <v-btn type="submit">Log In</v-btn>
    </form> -->
  </template>
  