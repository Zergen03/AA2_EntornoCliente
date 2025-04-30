export interface user {
    id?: number
    name: string
    email: string
    password: string
    IsVeteran: boolean
  }
  
//   <script setup lang="ts">
// import { useUserStore } from '@/stores/userStore';
// import { onMounted } from 'vue';

// const store = useUserStore()
// onMounted(() => {
//   store.fetchAll()
// })
// </script>

// <template>
//     <div>
//         <h1>USERS</h1>
//         <div v-for="user in store.users" :key="user.id">
//             {{ user.Name }}
//         </div>
//     </div>
//     <!-- <form @submit.prevent="handleLogin">
//       <AuthInput v-model="email" label="Email" />
//       <AuthInput v-model="password" label="Password" type="password" />
//       <v-btn type="submit">Log In</v-btn>
//     </form> -->
//   </template>
  