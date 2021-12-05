<template>
  <showcase-create v-bind="createData">
    <showcase-label class="col-md-6" label="Наименование">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.name"
        placeholder="Наименование"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Адрес">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.address"
        placeholder="Адрес"
      >
    </showcase-label>

    <showcase-label class="col-md-4" label="Тип">
      <select class="form-select" v-model="dataToSend.agentType">
        <option disabled value="">
          Тип контрагента
        </option>
        <option
          v-for="(item, index) in agentType"
          :key="index"
          :value="item.value"
        >
          {{ item.text }}
        </option>
      </select>
    </showcase-label>

    <showcase-label class="col-md-4" label="ИНН">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.inn"
        placeholder="ИНН"
      >
    </showcase-label>

    <showcase-label class="col-md-4" label="Расчетный счет">
      <input
        class="form-control"
        type="text"
        v-model="dataToSend.bill"
        placeholder="Расчетный счет"
      >
    </showcase-label>

    <showcase-label class="col-md-6" label="Телефон">
      <input
        class="form-control"
        v-imask="mask"
        :value="dataToSend.phone"
        @accept="onAccept"
      />
    </showcase-label>

    <showcase-label class="col-md-6" label="Электронная почта">
      <input
        type="text"
        class="form-control"
        v-model="dataToSend.email"
        placeholder="Электронная почта"
      >
    </showcase-label>

    <showcase-errors-list
      v-if="v$.$errors.length"
      :errors="v$.$errors"
    />

    <showcase-submit @click="sendToServer">
      <edit-icon />
      Создать
    </showcase-submit>
  </showcase-create>
</template>

<script>
import { IMaskDirective } from 'vue-imask'
import { useVuelidate } from '@vuelidate/core'
import ShowcaseErrorsList from '@/components/Showcase/showcase-errors-list'
import ShowcaseCreate from '@/components/Showcase/showcase-create'
import ShowcaseLabel from '@/components/Showcase/showcase-label-field'
import ShowcaseSubmit from '@/components/Showcase/showcase-submit-button'
import { EditIcon } from '@iconicicons/vue3'
import {
  required,
  maxLength,
  minLength,
  numeric,
  email,
  phone
} from '@/utils/validation/i18n-validators'

export default {
  name: 'AgentCreate',
  components: {
    ShowcaseCreate,
    ShowcaseLabel,
    ShowcaseSubmit,
    ShowcaseErrorsList,
    EditIcon
  },
  setup () {
    return { v$: useVuelidate() }
  },
  validations () {
    return {
      dataToSend: {
        agentType: { required },
        address: { required },
        name: { required },
        inn: {
          required,
          numeric,
          minLength: minLength(10),
          maxLength: maxLength(12)
        },
        bill: {
          required,
          numeric,
          minLength: minLength(20),
          maxLength: maxLength(20)
        },
        phone: { required, phone },
        email: { required, email }
      }
    }
  },
  data: () => {
    return {
      createData: {
        title: 'Создать контрагента'
      },
      agentType: [
        {
          text: 'Утилизатор',
          value: 'util'
        },
        {
          text: 'Клиент',
          value: 'client'
        },
        {
          text: 'Поставщик',
          value: 'supplier'
        },
        {
          text: 'ТК',
          value: 'tk'
        }
      ],
      dataToSend: {
        agentType: '',
        address: '',
        name: '',
        inn: '',
        bill: '',
        phone: '',
        email: ''
      },
      mask: {
        mask: '+{7}(000)000-00-00',
        lazy: false
      }
    }
  },
  directives: {
    imask: IMaskDirective
  },
  methods: {
    onAccept (e) {
      this.dataToSend.phone = e.detail.value
    },

    async sendToServer () {
      const isReady = await this.v$.$validate()

      if (!isReady) {
        console.log('Ошибка!')
      } else {
        console.log('Объект готов к отправке', this.dataToSend)
      }
    }
  }
}
</script>
