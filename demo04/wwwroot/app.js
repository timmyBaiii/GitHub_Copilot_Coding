const heightInput = document.getElementById('height');
const weightInput = document.getElementById('weight');
const ageInput = document.getElementById('age');
const sexInput = document.getElementById('sex');
const activityInput = document.getElementById('activityLevel');
const bmiButton = document.getElementById('bmiButton');
const bmrButton = document.getElementById('bmrButton');
const tdeeButton = document.getElementById('tdeeButton');
const resultBox = document.getElementById('result');

const requiredFor = {
  bmi: ['height', 'weight'],
  bmr: ['height', 'weight', 'age', 'sex'],
  tdee: ['height', 'weight', 'age', 'sex', 'activityLevel'],
};

const inputMap = {
  height: heightInput,
  weight: weightInput,
  age: ageInput,
  sex: sexInput,
  activityLevel: activityInput,
};

function isFilled(id) {
  const value = inputMap[id].value;
  return value !== null && value.toString().trim() !== '' && Number(value) > 0;
}

function updateButtons() {
  bmiButton.disabled = !requiredFor.bmi.every(isFilled);
  bmrButton.disabled = !requiredFor.bmr.every(isFilled);
  tdeeButton.disabled = !requiredFor.tdee.every(isFilled);
}

async function callApi(path, payload) {
  const response = await fetch(path, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(payload),
  });

  if (!response.ok) {
    const errorData = await response.json().catch(() => ({}));
    throw new Error(errorData.error || 'API 呼叫失敗');
  }

  return response.json();
}

function showResult(html) {
  resultBox.innerHTML = html;
}

function gatherBaseValues() {
  return {
    heightCm: Number(heightInput.value),
    weightKg: Number(weightInput.value),
  };
}

async function handleBmi() {
  const payload = gatherBaseValues();
  const data = await callApi('/calculate/bmi', payload);
  showResult(`<h2 class="text-xl font-semibold mb-2">BMI 結果</h2>
              <p>BMI：<strong>${data.bmi}</strong></p>
              <p>類別：<strong>${data.category}</strong></p>`);
}

async function handleBmr() {
  const payload = {
    ...gatherBaseValues(),
    age: Number(ageInput.value),
    sex: sexInput.value,
  };
  const data = await callApi('/calculate/bmr', payload);
  showResult(`<h2 class="text-xl font-semibold mb-2">BMR 結果</h2>
              <p>BMR：<strong>${data.bmr}</strong> 大卡/日</p>
              <p>公式：<strong>${data.formula}</strong></p>`);
}

async function handleTdee() {
  const payload = {
    ...gatherBaseValues(),
    age: Number(ageInput.value),
    sex: sexInput.value,
    activityLevel: activityInput.value,
  };
  const data = await callApi('/calculate/tdee', payload);
  showResult(`<h2 class="text-xl font-semibold mb-2">TDEE 結果</h2>
              <p>TDEE：<strong>${data.tdee}</strong> 大卡/日</p>
              <p>活動係數：<strong>${data.activityFactor}</strong></p>`);
}

[bmiButton, bmrButton, tdeeButton].forEach(button => button.addEventListener('click', async (event) => {
  event.preventDefault();
  try {
    if (event.target === bmiButton) await handleBmi();
    if (event.target === bmrButton) await handleBmr();
    if (event.target === tdeeButton) await handleTdee();
  } catch (error) {
    showResult(`<p class="text-red-600">${error.message}</p>`);
  }
}));

Object.values(inputMap).forEach(input => input.addEventListener('input', updateButtons));
updateButtons();
