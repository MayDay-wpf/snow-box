<script setup lang="ts">
import { ref } from "vue";
import TitleBar from "./components/TitleBar.vue";

const count = ref(0);
const message = ref("Welcome to Snow Box!");

const increment = () => {
  count.value++;
};

const decrement = () => {
  count.value--;
};
</script>

<template>
  <div class="app-wrapper">
    <TitleBar />
    <div class="app-container">
      <div class="header">
        <h1>Snow Box</h1>
        <p class="subtitle">Electron + Vue 3 + Vite + TypeScript</p>
      </div>

      <div class="content">
        <div class="card">
          <h2>{{ message }}</h2>
          <div class="counter">
            <button @click="decrement" class="btn">-</button>
            <span class="count">{{ count }}</span>
            <button @click="increment" class="btn">+</button>
          </div>
          <p class="hint">Click the buttons to change the counter</p>
        </div>

        <div class="info">
          <h3>Quick Start</h3>
          <ul>
            <li><code>npm run dev</code> - Start development server</li>
            <li>
              <code>npm run electron:dev</code> - Start Electron app in dev mode
            </li>
            <li><code>npm run build</code> - Build for production</li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.app-wrapper {
  width: 100%;
  height: 100vh;
  display: flex;
  flex-direction: column;
}

.app-container {
  flex: 1;
  padding: 2rem;
  padding-top: 3rem;
  max-width: 800px;
  margin: 0 auto;
  overflow-y: auto;
}

.header {
  margin-bottom: 3rem;
}

.header h1 {
  font-size: 3rem;
  margin-bottom: 0.5rem;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
}

.subtitle {
  font-size: 1.2rem;
  color: #888;
}

.content {
  display: flex;
  flex-direction: column;
  gap: 2rem;
}

.card {
  background: rgba(255, 255, 255, 0.05);
  border-radius: 12px;
  padding: 2rem;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

.card h2 {
  margin-bottom: 1.5rem;
  font-size: 1.5rem;
}

.counter {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 2rem;
  margin: 2rem 0;
}

.count {
  font-size: 3rem;
  font-weight: bold;
  min-width: 100px;
  color: #667eea;
}

.btn {
  width: 50px;
  height: 50px;
  font-size: 1.5rem;
  border-radius: 50%;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  border: none;
  cursor: pointer;
  transition: transform 0.2s, box-shadow 0.2s;
}

.btn:hover {
  transform: scale(1.1);
  box-shadow: 0 4px 12px rgba(102, 126, 234, 0.4);
}

.btn:active {
  transform: scale(0.95);
}

.hint {
  margin-top: 1rem;
  color: #888;
  font-size: 0.9rem;
}

.info {
  background: rgba(255, 255, 255, 0.05);
  border-radius: 12px;
  padding: 2rem;
  text-align: left;
}

.info h3 {
  margin-bottom: 1rem;
  font-size: 1.3rem;
}

.info ul {
  list-style: none;
  padding: 0;
}

.info li {
  margin: 0.8rem 0;
  padding-left: 1.5rem;
  position: relative;
}

.info li::before {
  content: "▸";
  position: absolute;
  left: 0;
  color: #667eea;
}

code {
  background: rgba(102, 126, 234, 0.2);
  padding: 0.2rem 0.5rem;
  border-radius: 4px;
  font-family: "Courier New", monospace;
  color: #667eea;
}

@media (prefers-color-scheme: light) {
  .card,
  .info {
    background: rgba(0, 0, 0, 0.05);
  }
}
</style>
