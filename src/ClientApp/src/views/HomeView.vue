<script setup>
import { ref, onMounted } from 'vue'

const count = ref(0)
const weatherforecast = ref(null);

const getWeatherForecast = async () => await fetch('/api/weatherforecast').then(r => r.json())

onMounted(async () => {
  weatherforecast.value = await getWeatherForecast() || [];
})
</script>

<template>
  <div class="card">
    <button type="button" @click="count++">count is {{ count }}</button>
    <p>
      Edit
      <code>views/HomeView.vue</code> to test HMR
    </p>
  </div>

  <section v-if="weatherforecast">
    <table>
      <thead>
        <tr>
          <th>Date</th>
          <th>Summary</th>
          <th>Temperature in Celsius</th>
          <th>Temperature in Fahrenheit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="summary in weatherforecast">
          <td>{{ summary.date }}</td>
          <td>{{ summary.summary }}</td>
          <td>{{ summary.temperatureC }}°</td>
          <td>{{ summary.temperatureF }}°</td>
        </tr>
      </tbody>
    </table>
  </section>
  <section v-else>
    <h2>Loading...</h2>
  </section>

  <p>
    Install
    <a href="https://marketplace.visualstudio.com/items?itemName=Vue.volar" target="_blank">Volar</a>
    in VSCode for a better DX
  </p>
  <p class="read-the-docs">Click on the Vite and Vue logos to learn more</p>
</template>

<style scoped>
.read-the-docs {
  color: #888;
}

table {
  background: #1A1A1A;
  border-radius: 0.25em;
  border-collapse: collapse;
  margin: 1em;
}

th {
  border-bottom: 1px solid #364043;
  color: #646cff;
  font-size: 1em;
  font-weight: 600;
  padding: 0.5em 1em;
  text-align: left;
}

td {
  color: #fff;
  font-weight: 400;
  padding: 0.65em 1em;
}

tbody tr {
  transition: background 0.25s ease;
}

tbody tr:hover {
  background: #646cff;
}
</style>
